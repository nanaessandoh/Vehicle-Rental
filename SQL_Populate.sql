INSERT INTO [dbo].[VehicleRentalBranches]([Name],[Address],[City],[Province],[Telephone],[OpenDate],[ImageUrl])
VALUES
('Calgary Car Rental','3460 White Oak Drive', 'Calgary','Alberta','816-668-5747','1990-05-13','/images/branches/1.jpg'),
('Edmonton Car Rental','857 Toy Avenue', 'Edmonton','Alberta','643-318-3235','1978-05-13','/images/branches/2.jpg'),
('Halifax Car Rental','1532th Street', 'Halifax','Nova Scotia','616-848-6339','1988-05-13','/images/branches/3.jpg'),
('Vancouver Car Rental','2816 Brand Road','Vancouver','British Columbia','511-515-3155','1965-05-13','/images/branches/4.jpg'),
('Surrey Car Rental','1181 Dominion St', 'Surrey','British Columbia','651-515-6518','1998-05-13','/images/branches/5.jpg'),
('Toronto Car Rental','230 Brook St', 'Toronto','Ontario','511-518-5311','1993-05-13','/images/branches/6.jpg'),
('Ottawa Car Rental','2571 Fourth Avenue', 'Ottawa','Ontario','855-511-9955','1987-05-13','/images/branches/7.jpg'),
('Regina Car Rental','3353nd Avenue', 'Regina','Saskatchwan','684-550-5151','1999-05-13','/images/branches/8.jpg'),
('Saskatoon Car Rental','1710 Sherbrooke Ouest', 'Saskatoon','Saskatchewan','515-315-3153','1987-05-13','/images/branches/9.jpg'),
('Winnipeg Car Rental','1476 St.John Street', 'Winnipeg','Manitoba','816-351-3131','1994-05-13','/images/branches/10.jpg'),
('St. Johns Car Rental','3137 MacLaren Street', 'St.Johns','Newfoundland','155-111-5181','1979-05-13','/images/branches/11.jpg'),
('Saint John Car Rental','3589 Bay Street', 'Saint John','New Brunswick','888-133-3545','1988-05-13','/images/branches/12.jpg'),
('Montreal Car Rental','2871 Kennedy Rd', 'Montreal','Quebec','358-656-6647','1998-05-13','/images/branches/13.jpg'),
('Victoria Car Rental','2839 Birkett Lane', 'Victoria','British Columbia','553-315-3555','1992-05-13','/images/branches/14.jpg'),
('Maple Ridge Car Rental','2162 Kinchant St', 'Maple Ridge','British Columbia','353-648-5488','1991-05-13','/images/branches/15.jpg');

SELECT * FROM [VehicleRental_Dev].[dbo].[VehicleRentalBranches]

INSERT INTO [dbo].[DriverLicenses]([Fees],[ExpiryDate],[IssueDate])
     VALUES
(0.00,'2025-12-30','2017-10-29'),
(0.00,'2024-08-01','2016-06-19'),
(0.00,'2023-03-03','2015-02-18'),
(5.55,'2027-06-05','2020-06-16'),
(0.52,'2021-10-24','2019-03-26'),
(6.87,'2023-06-23','2016-06-02'),
(45.50,'2024-11-14','2013-08-09'),
(0.00,'2022-01-13','2014-09-01'),
(2.85,'2021-05-29','2017-12-27'),
(0.00,'2023-12-04','2019-10-22');

SELECT * FROM [VehicleRental_Dev].[dbo].[DriverLicenses]

INSERT INTO [dbo].[Patrons]([FirstName],[LastName],[Address],[DateOfBirth],[TelephoneNumber],[DriverLicenseId],[VehicleRentalBranchId])
     VALUES
('John', 'Lampard', '3210 Charleton Ave', '1989-01-13','356-961-3135', 1,1),
('Sarah', 'Heys', '2395 Chemin Hudson', '1994-02-09','858-911-3125', 2,2),
('Brenda', 'Maloney', '1604 Duke Street', '1995-03-19','853-928-5525', 3,3),
('Colleen', 'Trudeau', '4005th Street', '1978-04-28','388-848-3688', 4,4),
('Mark', 'Banks', '4044th Street', '1999-11-21','813-961-3663', 5,5),
('James', 'Cosby', '3638 Adelaide St', '1987-12-30','963-622-3128', 6,6),
('Cassey', 'Trollo', '695 York St', '1976-01-08','355-683-6315', 7,7),
('Beatrice', 'Raymond', '2631 Merton Street', '1991-11-21','663-475-6155', 8,8),
('Steve', 'Woods', '2817 Manitoba Street', '1997-09-11','683-653-3533', 9,9),
('Justin', 'Lake', '4793 Glover Road', '1983-10-01','653-933-3688', 10,10);

SELECT * FROM [VehicleRental_Dev].[dbo].[Patrons]


INSERT INTO [dbo].[Statuses]([Name],[Description])
     VALUES
('Checked Out','The Vehicle has been checked out of the lot'),
('Available','The Vehicle is available for a patron'),
('Stolen/ Lost','The Vehicle has been reported stolen or lost'),
('On Hold','The Vehicle has been placed on hold due to maintenance');

SELECT * FROM [VehicleRental_Dev].[dbo].[Statuses]


INSERT INTO [dbo].[VehicleRentalAssets]([Make],[Model],[Cost],[ImageUrl],[LocationId],[Discriminator],[VIN],[BodyType],[Options],[Passengers],[Bags],[StatusId],[NumberOfUnits])
     VALUES
('BMW','3 Series',50,'/images/cars/1.png',1,'Car','228G882A965','Sedan','Heated Seats, Parking Assist, CD,Radio, Air Conditioning, ABS, Satellite Navigation',5,4,2,10),
('BMW','X1',58,'/images/cars/2.png',2,'Car','151T748K423','SUV','Heated Seats, Parking Assist, CD,Radio, Air Conditioning, ABS, Satellite Navigation',5,3,2,10),
('Cadillac','XTS',78,'/images/cars/3.png',3,'Car','	265T101H816','Sedan','Heated Seats, Parking Assist, CD,Radio, Air Conditioning, ABS, Satellite Navigation',5,0,2,10),
('Chevrolet','Malibu',45,'/images/cars/4.png',4,'Car','479K660S136','Sedan','Heated Seats, Parking Assist, CD,Radio, Air Conditioning, ABS, Satellite Navigation',5,2,2,10),
('Chevrolet','Spark',50,'/images/cars/5.png',5,'Car','504Y723J636','Saloon','Heated Seats, Parking Assist, CD,Radio, Air Conditioning, ABS, Satellite Navigation',4,5,2,10),
('Chevrolet','Suburban',78,'/images/cars/6.png',6,'Car','712J310E986','SUV','Heated Seats, Parking Assist, CD,Radio, Air Conditioning, ABS, Satellite Navigation',5,2,2,10),
('Chevrolet','Tahoe',80,'/images/cars/7.png',7,'Car','149J300N626','SUV','Heated Seats, Parking Assist, CD,Radio, Air Conditioning, ABS, Satellite Navigation',5,5,2,10),
('Chevrolet','Colorado',54,'/images/cars/8.png',8,'Car','077S570B612','Truck','Heated Seats, Parking Assist, CD,Radio, Air Conditioning, ABS, Satellite Navigation',5,5,2,10),
('Chrysler','300S',60,'/images/cars/9.png',9,'Car','093W818E276','Sedan','Heated Seats, Parking Assist, CD,Radio, Air Conditioning, ABS, Satellite Navigation',5,5,2,10),
('Dodge','Durango',84,'/images/cars/10.png',10,'Car','542H870N175','SUV','Heated Seats, Parking Assist, CD,Radio, Air Conditioning, ABS, Satellite Navigation',5,1,2,10),
('Dodge','Grand Caravan',52,'/images/cars/11.png',11,'Car','541E540H951','Van','Heated Seats, Parking Assist, CD,Radio, Air Conditioning, ABS, Satellite Navigation',7,0,2,10),
('Ford','Edge',59,'/images/cars/12.png',12,'Car','599Y294E923','SUV','Heated Seats, Parking Assist, CD,Radio, Air Conditioning, ABS, Satellite Navigation',5,4,2,10),
('Ford','Escape',49,'/images/cars/13.png',13,'Car','067T854K315','SUV','Heated Seats, Parking Assist, CD,Radio, Air Conditioning, ABS, Satellite Navigation',5,4,2,10),
('Ford','F150 Super Crew',69,'/images/cars/14.png',14,'Car','652D109Z596','Truck','Heated Seats, Parking Assist, CD,Radio, Air Conditioning, ABS, Satellite Navigation',5,2,2,10),
('Ford','Mustang',77,'/images/cars/15.png',15,'Car','462U282N211','Sedan','Heated Seats, Parking Assist, CD,Radio, Air Conditioning, ABS, Satellite Navigation',5,2,2,10),
('Ford','Transit Cargo',72,'/images/cars/16.png',1,'Car','323F416Y842','Van','Heated Seats, Parking Assist, CD,Radio, Air Conditioning, ABS, Satellite Navigation',2,2,2,10),
('Hyundai','Accent',45,'/images/cars/17.png',2,'Car','697D321N891','Sedan','Heated Seats, Parking Assist, CD,Radio, Air Conditioning, ABS, Satellite Navigation',5,6,2,10),
('Hyundai','Elantra',68,'/images/cars/18.png',3,'Car','577T127K772','Sedan','Heated Seats, Parking Assist, CD,Radio, Air Conditioning, ABS, Satellite Navigation',5,6,2,10),
('Jeep','Wrangler',54,'/images/cars/19.png',4,'Car','454R023Z185','SUV','Heated Seats, Parking Assist, CD,Radio, Air Conditioning, ABS, Satellite Navigation',5,2,2,10),
('Kia','Forte',78,'/images/cars/20.png',5,'Car','337N363K808','Sedan','Heated Seats, Parking Assist, CD,Radio, Air Conditioning, ABS, Satellite Navigation',5,2,2,10),
('MINI','Countryman',55,'/images/cars/21.png',6,'Car','419R595B723','Saloon','Heated Seats, Parking Assist, CD,Radio, Air Conditioning, ABS, Satellite Navigation',5,8,2,10),
('Nissan','Maxima',54,'/images/cars/22.png',7,'Car','072Q132J095','Sedan','Heated Seats, Parking Assist, CD,Radio, Air Conditioning, ABS, Satellite Navigation',5,8,2,10),
('Nissan','Qashqai',76,'/images/cars/23.png',8,'Car','322R363J136','SUV','Heated Seats, Parking Assist, CD,Radio, Air Conditioning, ABS, Satellite Navigation',5,9,2,10),
('Volkswagen','Jetta',43,'/images/cars/24.png',9,'Car','586E421G133','Saloon','Heated Seats, Parking Assist, CD,Radio, Air Conditioning, ABS, Satellite Navigation',5,3,2,10);


SELECT * FROM [VehicleRental_Dev].[dbo].[VehicleRentalAssets]

INSERT INTO [dbo].[BranchHours]([BranchId],[DayOfWeek],[OpenTime],[CloseTime])
     VALUES
(1, 1, 8, 17),
(1, 2, 8, 17),
(1, 3, 8, 17),
(1, 4, 8, 17),
(1, 5, 8, 17),
(1, 6, 8, 17),
(1, 7, 8, 17), 

(2, 1, 8, 17),
(2, 2, 8, 17),
(2, 3, 8, 17),
(2, 4, 8, 17),
(2, 5, 8, 17),
(2, 6, 8, 17),
(2, 7, 8, 17),   

(3, 1, 8, 17),
(3, 2, 8, 17),
(3, 3, 8, 17),
(3, 4, 8, 17),
(3, 5, 8, 17),
(3, 6, 8, 17),
(3, 7, 8, 17),   

(4, 1, 8, 17),
(4, 2, 8, 17),
(4, 3, 8, 17),
(4, 4, 8, 17),
(4, 5, 8, 17),
(4, 6, 8, 17),
(4, 7, 8, 17),   

(5, 1, 8, 17),
(5, 2, 8, 17),
(5, 3, 8, 17),
(5, 4, 8, 17),
(5, 5, 8, 17),
(5, 6, 8, 17),
(5, 7, 8, 17),   

(6, 1, 8, 17),
(6, 2, 8, 17),
(6, 3, 8, 17),
(6, 4, 8, 17),
(6, 5, 8, 17),
(6, 6, 8, 17),
(6, 7, 8, 17),   

(7, 1, 8, 17),
(7, 2, 8, 17),
(7, 3, 8, 17),
(7, 4, 8, 17),
(7, 5, 8, 17),
(7, 6, 8, 17),
(7, 7, 8, 17),   

(8, 1, 8, 17),
(8, 2, 8, 17),
(8, 3, 8, 17),
(8, 4, 8, 17),
(8, 5, 8, 17),
(8, 6, 8, 17),
(8, 7, 8, 17),   

(9, 1, 8, 17),
(9, 2, 8, 17),
(9, 3, 8, 17),
(9, 4, 8, 17),
(9, 5, 8, 17),
(9, 6, 8, 17),
(9, 7, 8, 17),   

(10, 1, 8, 17),
(10, 2, 8, 17),
(10, 3, 8, 17),
(10, 4, 8, 17),
(10, 5, 8, 17),
(10, 6, 8, 17),
(10, 7, 8, 17),   

(11, 1, 8, 17),
(11, 2, 8, 17),
(11, 3, 8, 17),
(11, 4, 8, 17),
(11, 5, 8, 17),
(11, 6, 8, 17),
(11, 7, 8, 17),   

(12, 1, 8, 17),
(12, 2, 8, 17),
(12, 3, 8, 17),
(12, 4, 8, 17),
(12, 5, 8, 17),
(12, 6, 8, 17),
(12, 7, 8, 17),   

(13, 1, 8, 17),
(13, 2, 8, 17),
(13, 3, 8, 17),
(13, 4, 8, 17),
(13, 5, 8, 17),
(13, 6, 8, 17),
(13, 7, 8, 17),   

(14, 1, 8, 17),
(14, 2, 8, 17),
(14, 3, 8, 17),
(14, 4, 8, 17),
(14, 5, 8, 17),
(14, 6, 8, 17),
(14, 7, 8, 17),   

(15, 1, 8, 17),
(15, 2, 8, 17),
(15, 3, 8, 17),
(15, 4, 8, 17),
(15, 5, 8, 17),
(15, 6, 8, 17),
(15, 7, 8, 17); 

SELECT * FROM [VehicleRental_Dev].[dbo].[BranchHours]