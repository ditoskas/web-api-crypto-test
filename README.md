# web-api-crypto-test
## Description
<p>
The project is been developed as part of a course that teaches the .Net core Web API feaures.
The main purpose of the API is to provide basic filtering capabilities to crypto block transactions 
provided by <a href="https://www.blockcypher.com">BlockCypher</a>
</p>
<p>
To achive that 2 end applications exists
<ul>
<li>API - .Net core Web Api application</li>
<li>BlockCypherSeeder - .Net core windows console application</li>
</ul>
</p>
The database engine is SQLite EF, and the location of the database is on the system's `local` folder
example in windows `C:\Users\XYZ\AppData\Local`.

The application is using the BlockCypherSeeder application to read data from BlockCypher, normalize it and store it in a local database.

Example URL: https://api.blockcypher.com/v1/eth/main/blocks/f768f96d875303ffe59b85c3e475964e4a593d360cb4a2d087a28c0db01e1705

Database Schema

<img src="https://github.com/ditoskas/web-api-crypto-test/blob/e7110a1761d1616f8bf48bff6f709df56c580f14/crypto-web-schema.png" />

---
## Development
The project has been developed with the <a href="https://www.freecodecamp.org/news/a-quick-introduction-to-clean-architecture-990c014448d2/">Clean Architecure</a> in mind.
Therefore 3 main folders exist that represent each layer of the architecture.
* Domain - Keep the main business rules
* Service - Is the mediator where reads the information from sources, transform it acording to the business rules and provide the info to upper layer.
* Presentation - The end user applications such as the web api and the console application (it utilize the services)

### Installation
Open the main solution `CryptoApiTest.sln` and set as start up project the `API` which exist in the Presentation folder.
Then open the `Package Manager Console` (Tools->Nu Get Package Manager->Package Manager Console) and run the command `Update-Database`

The system will start Building the project and will apply 4 migrations, at this moment you can run the `API` application and the `swagger` 
interface will popup for you to consume the API, default is: https://localhost:7006/swagger/index.html

### Seed the Database
To update our database records we need to use the BlockCypherSeeder application. The application is accepting 4 paratemeters with the order:
1. The symbol of the crypto to seed, default value is `BTC`
2. The network that belongs to the symbol, default value is `main`
3. The number of records to read, default value is 100
4. The action to execute, is either `seed` or `update` with the `seed` as default option

Please note that these values should exist in our database on cryptos and cryptonetworks tables and also should be available on the BlockChypher API

When we run the seeder the application is reading the latest block url or the latest from our database, using either the 
latest url from BlockCypher or the PreviousUrl from our database, the system is executing an API request to BlockCypher
it normalize the data and save it in our database (Have in mind to check the rate limits as it should not been reached or you will get an exception)

## API End Points
You can run the `Api` project on the visual studio and the swagger interface will load to test the API end points.

For educational purposes the Create Read Update Delete actions have been implemented for the Cryptos table.
Together with the main CryptoBlocks end points that can be used to filter the crypto block transactions.

### Cryptos
| Method        | URL                                     | Description                               |
|---------------|-----------------------------------------|-------------------------------------------|
| GET           | https://localhost:7006/api/Cryptos      | Read all cryptos from database            |
| POST          | https://localhost:7006/api/Cryptos      | Create new crypto in database             |
| GET           | https://localhost:7006/api/Cryptos/{id} | Read the details of on crypto record      |
| PUT           | https://localhost:7006/api/Cryptos/{id} | Update the information of a crypto record |
| DELETE        | https://localhost:7006/api/Cryptos/{id} | Delete a crypto record                    |

### CryptoBlocks
| Method        | URL                                            | Description                                              |
|---------------|------------------------------------------------|----------------------------------------------------------|
| GET           | https://localhost:7006/api/CryptoBlocks        | Read all cryptos blocks from database                    |
| GET           | https://localhost:7006/api/CryptoBlocks/{hash} | Read the details of on crypto block with the given hash  |

**Note:** The first end point `https://localhost:7006/api/CryptoBlocks` is returning paginated results (stored on `X-Pagination` header on the response) also
 the below query parameters can be used to filter the results
1. `Hash` - Read a record with the given hash
2. `HeightMin` - Read records with height greater than the given value
3. `HeightMax` - Read records with height less than the given value
4. `TimeMin` - Read records with time greater than the given value
5. `TimeMax` - Read records with time less than the given value
6. `Chain` - Read records that belong to specific chain
7. `PageNumber` - The number of the page 
8. `PageSize` - The size of each page

## Alternative Implementation
On the solution you will find also a web api project with name `Api2`. This is exactly the same functionality 
as the `Api`, the big difference is on the implementation technique.
On the `Api2` project the CQRS pattern using the MediatR middlweare has been used, this has been done to demonstrate a different approach for education reasons.

**Note:** You can run the `Api2` project and test the end points using the swagger interface