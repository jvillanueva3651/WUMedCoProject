!!!WARNING!!!
!!!WARNING!!!
!!!WARNING!!!

In order for the application to work properly with the database, you must modify ALL instances of the filepath referenced in the code. 

Luckily I have centralized this in one location.

Simply open the file "App.config.template" and change the connection string to your database path, including the database name and file type.
Then change the name of the file to "App.config"

Example: @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Files\Projects\WUMedCoProject\WUMedCo.mdf;Integrated Security=False"
     OR  @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Downloads\WUMedCoProject\WUMedCo.mdf;Integrated Security=False"