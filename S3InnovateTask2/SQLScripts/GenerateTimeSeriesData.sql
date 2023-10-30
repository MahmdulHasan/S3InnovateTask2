DECLARE @NumberOfBuildings INT = 1;
DECLARE @DataPointsPerTimestamp INT = 10;
DECLARE @minutesPerDay INT = 1440;
DECLARE @minutesPerYear INT = @minutesPerDay * 365;
DECLARE @TotalMinutes INT = @minutesPerYear * 2;

DECLARE @BuildingId INT = 1, @TimestampMinutes INT, @Timestamp DATETIME;

WHILE @BuildingId <= @NumberOfBuildings
BEGIN
    SET @TimestampMinutes = 0;
    WHILE @TimestampMinutes < @TotalMinutes
    BEGIN
        SET @Timestamp = DATEADD(MINUTE, -@TotalMinutes + @TimestampMinutes, GETDATE());

        DECLARE @DataPoint INT = 0;
        
		WHILE @DataPoint < @DataPointsPerTimestamp
        BEGIN

            DECLARE @ObjectId INT = FLOOR(RAND() * 2) + 1; 
            DECLARE @DataFieldId INT = FLOOR(RAND() * 2) + 1;

            DECLARE @RandomValue DECIMAL(18, 2) = RAND() * 10;

            INSERT INTO Reading (BuildingId, ObjectId, DataFieldId, Value, Timestamp)
            VALUES (@BuildingId, @ObjectId, @DataFieldId, @RandomValue, @Timestamp);

            SET @DataPoint = @DataPoint + 1;
        END

        SET @TimestampMinutes = @TimestampMinutes + 1;
    END

    SET @BuildingId = @BuildingId + 1;
END



