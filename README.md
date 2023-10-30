* Steps to run the project:
  
   1. Clone/download the project.
   2. Change the connection string.
   3. If you want to run the project using development database, download the backup from this url (https://shorturl.at/coGV5) restore the the dabase the run the project.
   4. Another alternative approch is to run the project, which will automatically execute the pending migrations. However, you will need to separately run the time series data generation script, which can be found in the SQLScripts 
      (https://shorturl.at/asHO4) folder.
   5. After running the project, you will find a Swagger document for the avaiable APIs.


* Optimization techniques applied for faster data fetching are as follows:

   1. Add indexes to the columns that will be used to filter the data.
   2. Retrieve the data from the database without tracking to improve data loading time.
   3. Fetch only requied columns, as this also improves performance.

* Still now there should be optimization area like

   1.  Data can be read using stored procedure, which can improve query execution time.
   2.  We can create summary tables to store pre-aggregated data, speeding up data retrieval for longer date ranges.
   3.  We can partion the data based on time intervals (e.g., daily, monthly) to improve query performance for specific date ranges.
   4.  We can implement data retentation policy to archieve old data.
