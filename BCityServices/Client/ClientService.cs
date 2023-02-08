using BCityData;

namespace BCityServices.Client
{
    public class ClientService : IClientService
    {
        public readonly BCityDBContext _db;
        static char nextCharactor = 'A';
        static string alphaPart = "";
        static int numericPartInt = 0;

        public ClientService(BCityDBContext dBContext)
        {
            _db = dBContext;
        }
        public ServiceResponse<BCityData.Models.Client> AddClient(BCityData.Models.Client client)
        {
            var newClient = new BCityData.Models.Client()
            {
                ClientCode = GenerateClientCode(client.Name),
                Name = client.Name
            };

            try
            {
                _db.Clients.Add(newClient);
                _db.SaveChanges();

                return new ServiceResponse<BCityData.Models.Client>()
                {
                    IsSuccess = true,
                    Message = $"Client ({ newClient.ClientCode}) was successfully added",
                    Data = newClient
                };
            } 
            catch 
            {
                return new ServiceResponse<BCityData.Models.Client>()
                {
                    IsSuccess = false,
                    Message = $"Failed to create Client ({ newClient.ClientCode})",
                    Data = newClient
                };
            }
        }

        public ServiceResponse<List<BCityData.Models.Client>> GetClients()
        {
            var clientList = _db.Clients.ToList();
            if (clientList.Any())
            {
                return new ServiceResponse<List<BCityData.Models.Client>>()
                {
                    IsSuccess = true,
                    Message = "Contacts were successfully loaded.",
                    Data = clientList
                };
            }
            return new ServiceResponse<List<BCityData.Models.Client>>()
            {
                IsSuccess = false,
                Message = "No client(s) found.",
                Data = clientList
            };

        }

        private string GenerateClientCode(string clientName)
        {
            //check the number of words contained in the client name
            var words = clientName.Split(' ');
            string alpha = "";


            if (words.Length > 2)
            {
                //if the client name contains more than one word, add the first letter of each word to the client ID
                alpha = words[0].Substring(0, 1) + words[1].Substring(0, 1) + words[2].Substring(0, 1);
            }
            else if (words.Length == 2)
            {
                //if the client name contains two words, add the first letter of each word to the client ID

                var secondWordLength = words[1].Length > 1;
                var firstWordLength = words[0].Length > 1;
                if (secondWordLength)
                {
                    alpha = words[0].Substring(0, 1) + words[1].Substring(0, 2);
                }
                else if (firstWordLength)
                {
                    alpha = words[0].Substring(0, 2) + words[1].Substring(0, 1);
                }
                else
                    alpha = words[0].Substring(0, 1) + words[1].Substring(0, 1) + nextCharactor;
            }
            else
            {
                //if the client name contains only one word, add the first three letters of the word to the client ID
                var clientNameLength = clientName.Length;
                if (clientNameLength > 2)
                {
                    alpha = clientName.Substring(0, 3);
                }
                else if (clientNameLength == 2)
                {
                    alpha = clientName.Substring(0, 2) + nextCharactor;
                }
                else
                {
                    alpha = clientName + nextCharactor + nextCharactor;
                }

            }
            ;
            //split the client ID into the alpha and numeric parts
            alphaPart = alpha.ToUpper();
            nextCharactor = alphaPart.Substring(2).ToCharArray()[0];
            GenerateCode();
            var newClientId = alphaPart + numericPartInt.ToString("000");

            return newClientId;
        }

        private void GenerateCode()
        {
            //search the list of client IDs for the alpha part
            var alphaPartList = _db.Clients.Where(x => x.ClientCode.Contains(alphaPart)).OrderBy(x => x).LastOrDefault();
            if (alphaPartList != null)
            {
                //convert the numeric part to an integer
                numericPartInt = Convert.ToInt32(alphaPartList.ClientCode.Substring(3));
                //increment the numeric part by 1

                if (numericPartInt < 999)
                {
                    //if the numeric part is less than 10, add a zero to the front of the numeric part
                    numericPartInt++;
                }
                else
                {
                    //change the last charactor of the alpha part to the next letter in the alphabet
                    if (nextCharactor == 'Z')
                    {
                        nextCharactor = 'A';
                    }
                    else
                    {
                        nextCharactor++;
                    }


                    alphaPart = alphaPart.Substring(0, 2) + nextCharactor;
                    /*alphaPartList = _db.Clients.Where(x => x.ClientCode.Contains(alphaPart)).OrderBy(x => x).LastOrDefault();
                    if (alphaPartList != null)
                    {
                        //convert the numeric part to an integer
                        numericPartInt = Convert.ToInt32(alphaPartList.ClientCode.Substring(3));
                        //increment the numeric part by 1

                        if (numericPartInt < 999)
                        {
                            //if the numeric part is less than 10, add a zero to the front of the numeric part
                            numericPartInt++;
                        }
                    }*/
                    GenerateCode();
                }
            }
            else
            {
                //if the alpha part is not found, add the alpha part and a numeric part of 001 to the list of client IDs
                numericPartInt = 1;

            }
        }
    }
}
