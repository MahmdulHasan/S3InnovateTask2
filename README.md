Project run steps:
1. Clone/download the project the project.
2. Change in the connection string.
3. If you want to run the project by using my development database then download the backup from this url 
   Or run the project it will automatically run the pending migration, but you need to then separately run the time series data generation script, you will find the script in the SQLScripts (https://shorturl.at/asHO4) folder.
4. You will find swagger document for the avaiable API.


Optimization technique applied for faster data fetching are below:

1. Add indexes in the columns that will use to filter the data
2. Retrieve the data from the data base with out tracking, so that data will be load faster.
3. Fetch only requied column, it also improve the performance.

Still now there should be optimization area like

1.  Data can be read using stored procedure, it will improve the query execution time.
2.  We can create summary tables to store pre aggregated data that will speed up retrieval of dat for longer date ranges.
3.  We can partitioning the data based on time intervals (e.g., daily, monthly) to improve query performance for specific date ranges.
