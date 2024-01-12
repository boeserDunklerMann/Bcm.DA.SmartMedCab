DROP USER 'DA.SmartMedCab.Hangfire';
DROP DATABASE DA_SmartMedCab_Hangfire;
CREATE DATABASE if NOT EXISTS DA_SmartMedCab_Hangfire;

CREATE USER 'DA.SmartMedCab.Hangfire'@'%' IDENTIFIED BY 'hangfire.0815';
GRANT ALL ON DA_SmartMedCab_Hangfire.* TO 'DA.SmartMedCab.Hangfire'@'%'
	WITH GRANT OPTION;
