# Timesheets

Timesheets is a Windows application that processes data from the ICTProtegeWX door system. It was created as a school project for 
deployment at CombiTel (my part time workplace). It was designed to calculate the number of hours that each employee has worked over a 
user defined timeframe.

Important Notes:
Requires .Net Framework 4.5.2 to run
If you are using a DPI scalling setting above 100%, this software will display incorrectly.
Works only for English(Australia) or a date format of DD/MM/YYYY

How to use Timesheets:

1. Open Timesheets.exe
2. Login with the default password: admin
3. A window opens, select a csv file with the appropriate data
4. The total hours worked of the selected user is displayed in the center of the window
   of the 'Hours' tab
5. Users who did not scan out are displayed in the right pane. Double click on a user's name
   to display how many hours they have worked.
6. Select another user by clicking on arrow on the drop down box
7. The name of the selected file is displayed on the bottom of the window
8. Tick the checkbox called 'Range of Days' to enable you to narrow the range of dates,
   or select a specific date by selecting the same date in both date pickers
9. Click on the 'Hours' tab to display how many hours the selected user has worked
10. Click on the 'Graph' tab to display how many hours that all users have worked
    within the range of days selected
11. To open another file, click File > Open
12. To export a pdf report of all users and their hours in the current range of days,
   click File > Export PDF Report
13. To export a CSV file containing all users and their hours in the current range of days,
   click File > Export CSV
