-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Oct 15, 2020 at 10:39 AM
-- Server version: 10.3.16-MariaDB
-- PHP Version: 7.3.7

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `dbbloodbank`
--

-- --------------------------------------------------------

--
-- Table structure for table `auditlogs`
--

CREATE TABLE `auditlogs` (
  `logID` int(11) NOT NULL,
  `logDateTime` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `logType` varchar(1) NOT NULL,
  `UserID` int(11) NOT NULL,
  `LogModule` varchar(100) NOT NULL,
  `logComment` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `bloodproduct`
--

CREATE TABLE `bloodproduct` (
  `ProductID` int(11) NOT NULL,
  `ProductName` varchar(100) NOT NULL,
  `BloodType` varchar(3) NOT NULL,
  `PricePerUnit` decimal(10,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `donations`
--

CREATE TABLE `donations` (
  `DonationID` int(11) NOT NULL,
  `DonorID` int(11) NOT NULL,
  `DateDonated` date NOT NULL,
  `DonationType` varchar(100) NOT NULL,
  `BProduct_Donated` varchar(100) NOT NULL,
  `Units` varchar(10) NOT NULL,
  `Status` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `donations`
--

INSERT INTO `donations` (`DonationID`, `DonorID`, `DateDonated`, `DonationType`, `BProduct_Donated`, `Units`, `Status`) VALUES
(1, 9, '2020-10-14', 'Whole blood', 'RBC', '5', 'Approved '),
(2, 1, '2020-10-15', 'Apheresis', 'Plasma', '5', 'To be tested ');

-- --------------------------------------------------------

--
-- Table structure for table `donor`
--

CREATE TABLE `donor` (
  `DonorID` int(11) NOT NULL,
  `DonorBloodType` varchar(3) NOT NULL,
  `DonorFname` varchar(100) NOT NULL,
  `DonorMname` varchar(100) NOT NULL,
  `DonorLname` varchar(100) NOT NULL,
  `DonorBirthDate` date NOT NULL,
  `DonorAge` int(3) NOT NULL,
  `DonorHeight` varchar(5) NOT NULL,
  `DonorWeight` varchar(5) NOT NULL,
  `DonorAddress` varchar(100) NOT NULL,
  `DonorCity` varchar(100) NOT NULL,
  `DonorZip` int(4) NOT NULL,
  `DonorContactNo` varchar(11) NOT NULL,
  `IsActive` varchar(50) NOT NULL,
  `AddedByID` int(11) NOT NULL,
  `AddedDate` timestamp NOT NULL DEFAULT current_timestamp(),
  `LastModifiedByID` int(11) NOT NULL,
  `LastModifiedDate` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `donor`
--

INSERT INTO `donor` (`DonorID`, `DonorBloodType`, `DonorFname`, `DonorMname`, `DonorLname`, `DonorBirthDate`, `DonorAge`, `DonorHeight`, `DonorWeight`, `DonorAddress`, `DonorCity`, `DonorZip`, `DonorContactNo`, `IsActive`, `AddedByID`, `AddedDate`, `LastModifiedByID`, `LastModifiedDate`) VALUES
(1, 'A+', 'adrian', 'aclan', 'alcantara', '2000-02-14', 20, '175', '71', '123 bolton isla', 'davao', 8000, '09156914520', 'Inactive', 0, '2020-10-14 16:02:03', 0, '2020-10-14 16:02:03'),
(8, 'A+', 'Adrian', 'Aclan', 'Alcantara', '2000-02-14', 12, '175', '70', '123 Bolton Isla', 'Davao City', 8000, '2147483647', 'Inactive', 0, '2020-10-15 03:51:23', 0, '2020-10-15 03:51:23'),
(9, 'A-', 'ASd', 'asdasd', 'asdads', '2000-02-14', 20, '147', '12', '321qweqew', 'qwe', 1234, '321654987', 'Active', 0, '2020-10-15 03:55:39', 0, '2020-10-15 03:55:39'),
(10, 'A-', 'ASd', 'asdasd', 'asdads', '2000-02-14', 20, '147', '12', '321qweqew', 'qwe', 1234, '321654987', 'Active', 0, '2020-10-15 03:55:40', 0, '2020-10-15 03:55:40'),
(14, 'O-', 'Adi', 'Acl', 'Alcan', '2000-02-20', 20, '175', '75', '123 bltn island', 'dvo', 8000, '2147483647', 'Active', 0, '2020-10-15 05:35:10', 0, '2020-10-15 05:35:10');

-- --------------------------------------------------------

--
-- Table structure for table `inventory/stock_in`
--

CREATE TABLE `inventory/stock_in` (
  `NVBSPNumber` int(11) NOT NULL,
  `ProductID` int(11) NOT NULL,
  `InStore` int(10) NOT NULL,
  `DateCollected` date NOT NULL,
  `DatetobeDisposed` date NOT NULL,
  `AddedByID` int(11) NOT NULL,
  `LastModifiedByID` int(11) NOT NULL,
  `LastModifiedDate` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `inventory/stock_out`
--

CREATE TABLE `inventory/stock_out` (
  `NVBSPNumber` int(11) NOT NULL,
  `ProductID` int(11) NOT NULL,
  `InStore` int(10) NOT NULL,
  `DateAddedtoInventory` date NOT NULL,
  `DatetobeDisposed` date NOT NULL,
  `AddedById` int(11) NOT NULL,
  `LastModifiedByID` int(11) NOT NULL,
  `LastModifiedDate` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `patient`
--

CREATE TABLE `patient` (
  `PatientID` int(11) NOT NULL,
  `PatientBloodType` varchar(3) NOT NULL,
  `PatientFname` varchar(100) NOT NULL,
  `PatientMname` varchar(100) NOT NULL,
  `PatientLname` varchar(100) NOT NULL,
  `PatientBirthDate` date NOT NULL,
  `PatientAge` int(3) NOT NULL,
  `PatientHeight` varchar(5) NOT NULL,
  `PatientWeight` varchar(5) NOT NULL,
  `PatientDisease` varchar(100) NOT NULL,
  `Address` varchar(100) NOT NULL,
  `City` varchar(100) NOT NULL,
  `Zip` int(5) NOT NULL,
  `PatientContactPerson` varchar(100) NOT NULL,
  `PatientContactNo` varchar(11) NOT NULL,
  `IsActive` varchar(10) NOT NULL,
  `AddedByID` int(10) NOT NULL,
  `AddedDate` timestamp NOT NULL DEFAULT current_timestamp(),
  `LastModifiedByID` int(10) NOT NULL,
  `LastModifiedDate` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `patient`
--

INSERT INTO `patient` (`PatientID`, `PatientBloodType`, `PatientFname`, `PatientMname`, `PatientLname`, `PatientBirthDate`, `PatientAge`, `PatientHeight`, `PatientWeight`, `PatientDisease`, `Address`, `City`, `Zip`, `PatientContactPerson`, `PatientContactNo`, `IsActive`, `AddedByID`, `AddedDate`, `LastModifiedByID`, `LastModifiedDate`) VALUES
(1, 'O+', 'adi', 'aclan', 'asd;lkj', '2000-02-14', 21, '170', '71', 'qxzc', '321qweqwe', 'qweqew', 3124, 'qweqweqe', '321654978', 'Inactive', 0, '2020-10-15 06:33:24', 0, '2020-10-15 06:33:24'),
(2, 'A+', 'Adrian', 'Aclan', 'Alcantara', '2000-02-14', 21, '175', '70', 'asdasd', '132 asdasd', 'asdasd', 2314, 'asdads', '321654987', 'Active', 0, '2020-10-15 06:36:33', 0, '2020-10-15 06:36:33');

-- --------------------------------------------------------

--
-- Table structure for table `tbluser`
--

CREATE TABLE `tbluser` (
  `UserID` int(5) NOT NULL,
  `Username` varchar(100) NOT NULL,
  `Password` varchar(100) NOT NULL,
  `FirstName` varchar(100) NOT NULL,
  `LastName` varchar(100) NOT NULL,
  `IsAdmin` tinyint(1) NOT NULL,
  `CreatedBy` int(10) NOT NULL,
  `CreatedDate` timestamp NOT NULL DEFAULT current_timestamp(),
  `Modifiedby` int(10) NOT NULL,
  `ModifiedDate` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `tbluser`
--

INSERT INTO `tbluser` (`UserID`, `Username`, `Password`, `FirstName`, `LastName`, `IsAdmin`, `CreatedBy`, `CreatedDate`, `Modifiedby`, `ModifiedDate`) VALUES
(1, 'user1', '1234', 'Adrian', 'Alcantara', 0, 0, '2020-10-08 06:44:41', 0, '2020-10-08 06:44:41'),
(8, 'qwe1', '1233', 'asd', 'qwe', 0, 0, '2020-10-14 17:27:11', 0, '2020-10-14 17:27:11'),
(9, 'qwe12', 'qwe1', 'asd', 'asd', 0, 0, '2020-10-14 17:30:52', 0, '2020-10-14 17:30:52'),
(10, 'user2', 'adr123', 'Adi', 'Alcan', 0, 0, '2020-10-15 05:34:11', 0, '2020-10-15 05:34:11');

-- --------------------------------------------------------

--
-- Table structure for table `transactionrecords`
--

CREATE TABLE `transactionrecords` (
  `TransactionID` int(11) NOT NULL,
  `PatientID` int(11) NOT NULL,
  `TransactionDate` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `ProductID` int(11) NOT NULL,
  `NVBSPNumber` int(11) NOT NULL,
  `Quantity(Units)` int(11) NOT NULL,
  `PaymentMethod` varchar(100) NOT NULL,
  `Total_Amount` decimal(11,0) NOT NULL,
  `CardNumber` int(11) DEFAULT NULL,
  `CardOwner` varchar(100) DEFAULT NULL,
  `PaymentNetwork` varchar(100) DEFAULT NULL,
  `CreatedByID` int(11) NOT NULL,
  `CreatedDate` timestamp NOT NULL DEFAULT current_timestamp(),
  `LastModifiedByID` int(11) NOT NULL,
  `LastModifiedDate` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `auditlogs`
--
ALTER TABLE `auditlogs`
  ADD PRIMARY KEY (`logID`),
  ADD KEY `UserID` (`UserID`);

--
-- Indexes for table `bloodproduct`
--
ALTER TABLE `bloodproduct`
  ADD PRIMARY KEY (`ProductID`);

--
-- Indexes for table `donations`
--
ALTER TABLE `donations`
  ADD PRIMARY KEY (`DonationID`),
  ADD KEY `DonorID` (`DonorID`);

--
-- Indexes for table `donor`
--
ALTER TABLE `donor`
  ADD PRIMARY KEY (`DonorID`),
  ADD KEY `AddedByID` (`AddedByID`),
  ADD KEY `LastModifiedByID` (`LastModifiedByID`);

--
-- Indexes for table `inventory/stock_in`
--
ALTER TABLE `inventory/stock_in`
  ADD PRIMARY KEY (`NVBSPNumber`),
  ADD KEY `ProductID` (`ProductID`),
  ADD KEY `SerialNumber` (`NVBSPNumber`),
  ADD KEY `AddedByID` (`AddedByID`,`LastModifiedByID`);

--
-- Indexes for table `inventory/stock_out`
--
ALTER TABLE `inventory/stock_out`
  ADD PRIMARY KEY (`NVBSPNumber`),
  ADD KEY `ProductID` (`ProductID`),
  ADD KEY `SerialNumber` (`NVBSPNumber`),
  ADD KEY `AddedById` (`AddedById`,`LastModifiedByID`);

--
-- Indexes for table `patient`
--
ALTER TABLE `patient`
  ADD PRIMARY KEY (`PatientID`),
  ADD KEY `AddedByID` (`AddedByID`,`LastModifiedByID`);

--
-- Indexes for table `tbluser`
--
ALTER TABLE `tbluser`
  ADD PRIMARY KEY (`UserID`);

--
-- Indexes for table `transactionrecords`
--
ALTER TABLE `transactionrecords`
  ADD PRIMARY KEY (`TransactionID`),
  ADD KEY `NVBSPNumber` (`NVBSPNumber`),
  ADD KEY `ProductID` (`ProductID`),
  ADD KEY `PatientID` (`PatientID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `auditlogs`
--
ALTER TABLE `auditlogs`
  MODIFY `logID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `bloodproduct`
--
ALTER TABLE `bloodproduct`
  MODIFY `ProductID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `donations`
--
ALTER TABLE `donations`
  MODIFY `DonationID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `donor`
--
ALTER TABLE `donor`
  MODIFY `DonorID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT for table `inventory/stock_in`
--
ALTER TABLE `inventory/stock_in`
  MODIFY `NVBSPNumber` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `inventory/stock_out`
--
ALTER TABLE `inventory/stock_out`
  MODIFY `NVBSPNumber` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `patient`
--
ALTER TABLE `patient`
  MODIFY `PatientID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `tbluser`
--
ALTER TABLE `tbluser`
  MODIFY `UserID` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `transactionrecords`
--
ALTER TABLE `transactionrecords`
  MODIFY `TransactionID` int(11) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
