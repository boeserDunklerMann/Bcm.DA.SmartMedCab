DROP USER 'DA.SmartMedCab';
DROP DATABASE 'DA_SmartMedCab';
CREATE DATABASE if NOT EXISTS DA_SmartMedCab;

CREATE USER 'DA.SmartMedCab'@'%' IDENTIFIED BY 'SmartMedCab.240112';
GRANT ALL ON DA_SmartMedCab.* TO 'DA.SmartMedCab'@'%'
	WITH GRANT OPTION;

