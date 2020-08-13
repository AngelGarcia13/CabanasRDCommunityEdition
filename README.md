# CabanasRDCommunityEdition
Your favorite app to find motels near you!

Before building the app please add a secrets.json file in the root of src/App/CabanasRD with the following structure:

    {
      "ApiKey":"YOUR-AZURE-FUNCTION-KEY"
    }

Before running the Azure Function (CabanasRDServerlessAPI), plese add a local.settings.json in the root of the project with the following structure:

    "ConnectionStrings": {

        "CosmosDBConnection": "AccountEndpoint=https://cabanas-cosmos-account.documents.azure.com:443/;AccountKey=YOUR_KEY_HERE;"

     }
