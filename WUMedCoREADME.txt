!!!WARNING!!!
!!!WARNING!!!
!!!WARNING!!!

In order for the application to work properly with the database, you must modify ALL instances of the filepath referenced in the code. 

Luckily I have centralized this in one location.

Simply open the file "WUMedCoPath.cs" and change the connection string to your database path, including the database name and file type.

Example: @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Files\Projects\WUMedCoProject\WUMedCo.mdf;Integrated Security=True"
     OR  @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Downloads\WUMedCoProject\WUMedCo.mdf;Integrated Security=True"

Simply put this string, edited with your filepath, into the connection string variable and it will change all usages in the code to properly use the database in your directory.