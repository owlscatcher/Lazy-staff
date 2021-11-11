# Lazy staff v0.0.1
## This is a very early project where I studied the API .Net Framework.
### I apologize in advance for the pain caused to you (someday I will refactor it).
![Снимок1](https://user-images.githubusercontent.com/46975515/141265618-44084263-a260-437f-af53-e926a18ab659.PNG)

## For what?..
We very often had to fill out forms, double-check the dates of the dosimetric equipment, it was very difficult to look for some device and remember where we installed it
This little utility can:
1. Connects to the database at startup;
2. Checks the dates of the technical test at the devices;
3. Marks them:
    * Red       -- date expired
    * Yellow    -- prepare for shipment
    * Green     -- in stock
    * Blue      -- sent to the testing service
    * Gray      -- removed from the register
4. When sending the device for testing, it updates the table in the database and fills in the .pdf form with the necessary data about the device, after which it sends the form for printing.
5. There is a convenient function of replacing the device with another device.
6. Can output data from the selected category in .xlsx

## Dependences
1. iTextSharp                       -Version 5.5.13
2. Microsoft.Office.Interop.Excel   -Version 15.0.4795.1000
3. Microsoft.Build.Utilities.Core   -Version 14.3.0
4. FreeSpire.PDF                    -Version 5.1.0
5. Costura.Fody                     -Version 4.0.0

At this stage, the utility requires Microsoft Excel installed, since it uses Interop.Excel. In the future, I would like to abandon the use of this shit and switch to Open XML.
