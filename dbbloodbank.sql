-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Oct 25, 2020 at 06:40 AM
-- Server version: 10.4.14-MariaDB
-- PHP Version: 7.3.22

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
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
  `UserID` int(11) DEFAULT NULL,
  `LogModule` varchar(100) NOT NULL,
  `logComment` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `auditlogs`
--

INSERT INTO `auditlogs` (`logID`, `logDateTime`, `logType`, `UserID`, `LogModule`, `logComment`) VALUES
(274, '2020-10-25 02:15:59', '1', 14, 'Log-in', 'User has successfully Logged-In'),
(275, '2020-10-25 02:16:29', '2', 14, 'Donor', 'Donor Added'),
(276, '2020-10-25 02:16:49', '3', 14, 'Donor', 'Donor Updated'),
(277, '2020-10-25 02:17:12', '3', 14, 'Donor', 'Donor Updated'),
(278, '2020-10-25 02:17:30', '4', 14, 'Donor', 'Donor Deleted'),
(279, '2020-10-25 02:18:18', '2', 14, 'Patient', 'Patient Added'),
(280, '2020-10-25 02:18:31', '3', 14, 'Patient', 'Patient Updated'),
(281, '2020-10-25 02:18:42', '4', 14, 'Patient', 'Patient Deleted'),
(282, '2020-10-25 02:19:03', '3', 14, 'Transaction', 'Transaction Updated'),
(283, '2020-10-25 02:19:16', '6', 14, 'Logout', 'Log out'),
(284, '2020-10-25 03:39:34', '1', 14, 'Log-in', 'User has successfully Logged-In'),
(285, '2020-10-25 03:39:55', '6', 14, 'Logout', 'Log out'),
(286, '2020-10-25 03:40:37', '1', 14, 'Log-in', 'User has successfully Logged-In'),
(287, '2020-10-25 03:41:19', '6', 14, 'Logout', 'Log out'),
(288, '2020-10-25 03:41:25', '1', 14, 'Log-in', 'User has successfully Logged-In'),
(289, '2020-10-25 03:41:44', '6', 14, 'Logout', 'Log out'),
(290, '2020-10-25 03:42:30', '1', 14, 'Log-in', 'User has successfully Logged-In'),
(291, '2020-10-25 03:43:40', '2', 14, 'Donor', 'Donor Added'),
(292, '2020-10-25 03:44:21', '3', 14, 'Donor', 'Donor Updated'),
(293, '2020-10-25 03:44:53', '4', 14, 'Donor', 'Donor Deleted'),
(294, '2020-10-25 03:45:47', '2', 14, 'Donation', 'Donation Added'),
(295, '2020-10-25 03:46:04', '3', 14, 'Donation', 'Donation Updated'),
(296, '2020-10-25 03:46:47', '2', 14, 'Stock In', 'Stock Added'),
(297, '2020-10-25 03:48:05', '2', 14, 'Transaction', 'Transaction Added'),
(298, '2020-10-25 03:49:29', '2', 14, 'Patient', 'Patient Added'),
(299, '2020-10-25 03:50:11', '3', 14, 'Patient', 'Patient Updated'),
(300, '2020-10-25 03:50:59', '4', 14, 'Patient', 'Patient Deleted'),
(301, '2020-10-25 03:51:26', '2', 14, 'User', 'User Added'),
(302, '2020-10-25 03:51:31', '6', 14, 'Logout', 'Log out'),
(303, '2020-10-25 03:51:38', '1', 17, 'Log-in', 'User has successfully Logged-In'),
(304, '2020-10-25 03:51:48', '3', 17, 'Donor', 'Donor Updated'),
(305, '2020-10-25 03:53:16', '6', 17, 'Logout', 'Log out'),
(306, '2020-10-25 03:56:08', '1', 14, 'Log-in', 'User has successfully Logged-In'),
(307, '2020-10-25 03:57:38', '2', 14, 'Donor', 'Donor Added'),
(308, '2020-10-25 03:58:10', '3', 14, 'Donor', 'Donor Updated'),
(309, '2020-10-25 03:59:00', '4', 14, 'Donor', 'Donor Deleted'),
(310, '2020-10-25 03:59:44', '2', 14, 'Donation', 'Donation Added'),
(311, '2020-10-25 04:00:05', '4', 14, 'Donation', 'Donation Deleted'),
(312, '2020-10-25 04:00:16', '3', 14, 'Donation', 'Donation Updated'),
(313, '2020-10-25 04:01:06', '2', 14, 'Stock In', 'Stock Added'),
(314, '2020-10-25 04:02:33', '2', 14, 'Transaction', 'Transaction Added'),
(315, '2020-10-25 04:03:20', '3', 14, 'Transaction', 'Transaction Updated'),
(316, '2020-10-25 04:03:56', '2', 14, 'User', 'User Added'),
(317, '2020-10-25 04:04:02', '6', 14, 'Logout', 'Log out'),
(318, '2020-10-25 04:04:09', '1', 18, 'Log-in', 'User has successfully Logged-In'),
(319, '2020-10-25 04:05:39', '3', 18, 'Patient', 'Patient Updated'),
(320, '2020-10-25 04:06:36', '3', 18, 'Donor', 'Donor Updated');

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

--
-- Dumping data for table `bloodproduct`
--

INSERT INTO `bloodproduct` (`ProductID`, `ProductName`, `BloodType`, `PricePerUnit`) VALUES
(1, 'Whole Blood', 'A+', '1500'),
(2, 'Whole Blood', 'A-', '1500'),
(3, 'Whole Blood', 'B+', '1500'),
(4, 'Whole Blood', 'B-', '1500'),
(5, 'Whole Blood', 'AB+', '1500'),
(6, 'Whole Blood', 'AB-', '1500'),
(7, 'Whole Blood', 'O+', '1500'),
(8, 'Whole Blood', 'O-', '1500'),
(9, 'RBC(Red Blood Cells)', 'A+', '1000'),
(10, 'RBC(Red Blood Cells)', 'A-', '1000'),
(11, 'RBC(Red Blood Cells)', 'B+', '1000'),
(12, 'RBC(Red Blood Cells)', 'B-', '1000'),
(13, 'RBC(Red Blood Cells)', 'AB+', '1000'),
(14, 'RBC(Red Blood Cells)', 'AB-', '1000'),
(15, 'RBC(Red Blood Cells)', 'O+', '1000'),
(16, 'RBC(Red Blood Cells)', 'O-', '1000'),
(17, 'Plasma', 'A+', '1000'),
(18, 'Plasma', 'A-', '1000'),
(19, 'Plasma', 'B+', '1000'),
(20, 'Plasma', 'B-', '1000'),
(21, 'Plasma', 'AB+', '1000'),
(22, 'Plasma', 'AB-', '1000'),
(23, 'Plasma', 'O+', '1000'),
(24, 'Plasma', 'O-', '1000'),
(25, 'Platelets', 'A+', '1000'),
(26, 'Platelets', 'A-', '1000'),
(27, 'Platelets', 'B+', '1000'),
(28, 'Platelets', 'B-', '1000'),
(29, 'Platelets', 'AB+', '1000'),
(30, 'Platelets', 'AB-', '1000'),
(31, 'Platelets', 'O+', '1000'),
(32, 'Platelets', 'O-', '1000'),
(33, 'Cryoprecipitate', 'A+', '700'),
(34, 'Cryoprecipitate', 'A-', '700'),
(35, 'Cryoprecipitate', 'B+', '700'),
(36, 'Cryoprecipitate', 'B-', '700'),
(37, 'Cryoprecipitate', 'AB+', '700'),
(38, 'Cryoprecipitate', 'AB-', '700'),
(39, 'Cryoprecipitate', 'O+', '700'),
(40, 'Cryoprecipitate', 'O-', '700'),
(41, 'Cryosupernatant', 'A+', '700'),
(42, 'Cryosupernatant', 'A-', '700'),
(43, 'Cryosupernatant', 'B+', '700'),
(44, 'Cryosupernatant', 'B-', '700'),
(45, 'Cryosupernatant', 'AB+', '700'),
(46, 'Cryosupernatant', 'AB-', '700'),
(47, 'Cryosupernatant', 'O+', '700'),
(48, 'Cryosupernatant', 'O-', '700');

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
(2, 1, '2020-10-15', 'Apheresis', 'Platelet', '5', 'Approved'),
(5, 8, '2020-10-16', 'Whole blood', 'Whole blood', '4', 'Approved '),
(6, 14, '2020-10-16', 'Whole blood', 'Whole blood', '1', 'Approved '),
(9, 8, '2020-10-16', 'Apheresis', 'Plasma', '14', 'Approved '),
(10, 16, '2020-10-23', 'Whole blood', 'Whole blood', '6', 'Approved '),
(11, 14, '2020-10-24', 'Apheresis', 'Plasma', '2', 'Approved '),
(12, 25, '2020-10-25', 'Apheresis', 'RBC(Red Blood Cells)', '2', 'Approved'),
(14, 37, '2020-10-25', 'Whole blood', 'Whole blood', '1', 'Approved'),
(15, 37, '2020-10-26', 'Whole blood', 'Whole blood', '1', 'Approved'),
(16, 15, '2020-10-25', 'Whole blood', 'Whole blood', '1', 'Approved'),
(17, 37, '2020-10-25', 'Whole blood', 'Whole blood', '1', 'Approved'),
(18, 37, '2020-10-25', 'Whole blood', 'Whole blood', '1', 'Approved'),
(19, 37, '2020-10-25', 'Whole blood', 'Whole blood', '1', 'Approved'),
(20, 37, '2020-10-25', 'Whole blood', 'Whole blood', '1', 'Approved');

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
  `AddedByID` int(11) DEFAULT NULL,
  `AddedDate` timestamp NULL DEFAULT NULL,
  `LastModifiedByID` int(11) DEFAULT NULL,
  `LastModifiedDate` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `donor`
--

INSERT INTO `donor` (`DonorID`, `DonorBloodType`, `DonorFname`, `DonorMname`, `DonorLname`, `DonorBirthDate`, `DonorAge`, `DonorHeight`, `DonorWeight`, `DonorAddress`, `DonorCity`, `DonorZip`, `DonorContactNo`, `IsActive`, `AddedByID`, `AddedDate`, `LastModifiedByID`, `LastModifiedDate`) VALUES
(15, 'B+', 'Adria', 'Alca', 'Tara', '2000-02-14', 20, '175', '70', '123 Bolton', 'Davao', 8000, '09156914520', 'Active', 0, '2020-10-15 14:57:04', 0, '2020-10-15 14:57:04'),
(16, 'A-', 'Adi', 'Acl', 'Alcan', '2000-02-14', 20, '175', '70', '132 Bltn Isl', 'Davao', 8000, '09156914520', 'Active', 0, '2020-10-15 15:20:33', 0, '2020-10-15 15:20:33'),
(17, 'A-', 'Yesa', 'Acal', 'Alcan', '2000-03-11', 25, '160', '65', '213 bltn isl', 'Davao', 8000, '09156914520', 'Active', 0, '2020-10-15 15:22:41', 0, '2020-10-15 15:22:41'),
(18, 'AB-', 'Ariesa', 'Aclan', 'Alcantara', '2000-03-11', 25, '175', '70', '123 Bolton Isla', '123 Bolton', 8000, '0915647892', 'Active', 0, '2020-10-15 15:32:34', 0, '2020-10-15 15:32:34'),
(19, 'A-', 'Adrian', 'Aclan', 'Alcantara', '2000-02-14', 20, '175', '70', '123 Bolton Isla', 'Davao City', 8000, '09156914520', 'Active', 0, '2020-10-16 01:14:41', 0, '2020-10-16 01:14:41'),
(20, 'A+', 'Adi', 'Alcan', 'Aclan', '2000-02-14', 20, '170', '70', '123 asdsa', 'davao', 8000, '091235456', 'Active', 0, '2020-10-16 01:19:24', 0, '2020-10-16 01:19:24'),
(21, 'A-', 'Miggy', 'Emmanuel', 'Fernandez', '1999-01-03', 21, '168', '60', 'asdasd', 'davao', 8000, '09321654987', 'Active', 0, '2020-10-16 01:29:43', 0, '2020-10-16 01:29:43'),
(24, 'A+', 'Miguel', 'Emmanuel', 'Fernandez', '2000-01-13', 20, '170', '70', '321asdhjk', 'qwegcx', 3215, '987654321', 'Inactive', 0, '2020-10-16 01:33:57', 0, '2020-10-16 01:33:57'),
(25, 'A-', 'asdasd', 'qwe', 'zxcasd', '2000-02-14', 20, '170', '70', '321asdasd', 'asdqwe', 3215, '32165498721', 'Active', 0, '2020-10-16 01:39:12', 0, '2020-10-16 01:39:12'),
(26, 'A-', 'asdfa', 'qweqew', 'asdasdf', '2000-02-14', 20, '123', '21', '321asdasd', 'asdasd', 3215, '3213132121', 'Inactive', 0, '2020-10-16 01:56:03', 0, '2020-10-16 01:56:03'),
(29, 'B-', 'Sheeno', 'char', 'Salera', '1999-03-12', 21, '165', '60', '123 Matina', 'Davao', 8000, '09123456789', 'Inactive', 0, '2020-10-16 08:27:34', 0, '2020-10-16 08:27:34'),
(30, 'AB-', 'Kevin', 'Brian', 'Sabado', '2000-01-12', 20, '165', '65', '123 Matina', 'Davao City', 8000, '09123456789', 'Active', 0, '2020-10-16 08:35:05', 0, '2020-10-16 08:35:05'),
(32, 'B-', 'Val', 'Adi', 'Aclan', '2000-02-14', 20, '170', '70', '123 bolton', 'davao', 8000, '09123456789', 'Active', 0, '2020-10-23 14:51:01', 0, '2020-10-23 14:51:01'),
(34, 'B+', 'Miggy', 'Penaso', 'Fernandez', '2000-01-13', 20, '165', '70', 'Talomo', 'Davao', 8000, '09256366444', 'Active', 14, '2020-10-25 00:36:25', NULL, '2020-10-25 00:36:25'),
(36, 'A+', 'Miguel', 'Penaso', 'Fernandez', '2000-10-10', 20, '165', '65', 'Talomo', 'Davao', 8000, '092564235', 'Active', 14, '2020-10-25 00:44:44', NULL, '2020-10-25 00:44:44'),
(37, 'A+', 'Miguel', 'Penaso', 'Fernandez', '1998-10-10', 21, '165', '65', 'Talomo', 'Davao', 5000, '09256346444', 'Active', 14, '2020-10-25 00:51:10', 18, '2020-10-25 04:06:35');

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
  `AddedByID` int(10) DEFAULT NULL,
  `AddedDate` timestamp NULL DEFAULT NULL,
  `LastModifiedByID` int(10) DEFAULT NULL,
  `LastModifiedDate` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `patient`
--

INSERT INTO `patient` (`PatientID`, `PatientBloodType`, `PatientFname`, `PatientMname`, `PatientLname`, `PatientBirthDate`, `PatientAge`, `PatientHeight`, `PatientWeight`, `PatientDisease`, `Address`, `City`, `Zip`, `PatientContactPerson`, `PatientContactNo`, `IsActive`, `AddedByID`, `AddedDate`, `LastModifiedByID`, `LastModifiedDate`) VALUES
(10, 'A+', 'Adrian', 'Aclan', 'Alcantara', '2000-02-14', 20, '173', '70', 'Asthma', '123 Bolton Isla', 'Davao', 8000, 'Arnel Alcantara', '09321654987', 'Active', 0, '2020-10-16 02:26:33', 14, '2020-10-16 02:26:33'),
(11, 'A+', 'asdasd', 'asdads', 'asdad', '2000-02-14', 20, '174', '70', 'asda', '312asdasad', 'sdasda', 3215, 'asdasdas', '09321654987', 'Active', 0, '2020-10-16 02:27:03', 0, '2020-10-16 02:27:03'),
(13, 'B+', 'Adi', 'Acla', 'Alcan', '2000-02-14', 20, '175', '70', 'Astham', '123 Bolton', 'Davao', 8000, 'Arnel Alcantara', '09123456789', 'Active', 0, '2020-10-16 08:07:05', 0, '2020-10-16 08:07:05'),
(14, 'AB+', 'Adi', 'Acla', 'Alcan', '2000-02-14', 20, '175', '70', 'Asthma', '123 Bolton', 'Davao', 8000, 'Arnel', '09123456789', 'Inactive', 0, '2020-10-16 08:11:01', 1, '2020-10-16 08:11:01'),
(15, 'AB+', 'Lenra', 'Ronquillo', 'Alcantara', '1979-12-27', 55, '170', '70', 'Asthma', '123 Bolton', 'Davao', 8000, 'Andy Alcantara', '09156914520', 'Inactive', 1, '2020-10-16 08:14:38', 1, '2020-10-16 08:14:38'),
(16, 'A-', 'Val', 'P', 'Alcan', '2000-02-14', 20, '170', '70', 'Asthma', '123 bolton isla', 'davao', 8000, 'Adi Alcant', '09123456789', 'Active', 1, '2020-10-23 14:48:00', 0, '2020-10-23 14:48:00'),
(17, 'B+', 'Qun', 'Das', 'Adri', '2000-02-14', 20, '170', '78', 'Asthma', '123 asdasd', 'dvo', 8900, 'Adri Alca', '09321654987', 'Active', 1, '2020-10-23 16:16:02', 0, '2020-10-23 16:16:02'),
(20, 'B+', 'Miguel', 'Emmanuel', 'Fernandez', '2000-10-10', 20, '165', '65', 'Cancer', 'Talomo', 'Davao', 5000, 'Primalin', '4654654', 'Active', 14, '2020-10-25 01:12:13', 14, '2020-10-25 01:12:13'),
(21, 'B+', 'Miguel', 'Penaso', 'Fernandez', '2000-10-10', 20, '165', '65', 'Cancer', 'Talomo', 'Davao', 8000, 'Primalin', '092665454', 'Active', 14, '2020-10-25 01:47:33', 18, '2020-10-25 04:05:38');

-- --------------------------------------------------------

--
-- Table structure for table `stock_in`
--

CREATE TABLE `stock_in` (
  `NVBSPNumber` int(11) NOT NULL,
  `ProductID` int(11) NOT NULL,
  `InStore` int(10) NOT NULL,
  `DateCollected` date NOT NULL,
  `DatetobeDisposed` date NOT NULL,
  `AddedByID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `stock_in`
--

INSERT INTO `stock_in` (`NVBSPNumber`, `ProductID`, `InStore`, `DateCollected`, `DatetobeDisposed`, `AddedByID`) VALUES
(6, 2, 1, '2020-10-23', '2020-11-27', 1),
(10, 10, 2, '2020-10-25', '2020-12-06', 0),
(19, 1, 0, '2020-10-25', '2020-11-29', 14);

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
  `CreatedBy` int(10) DEFAULT NULL,
  `CreatedDate` timestamp NOT NULL DEFAULT current_timestamp(),
  `Modifiedby` int(10) DEFAULT NULL,
  `ModifiedDate` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `tbluser`
--

INSERT INTO `tbluser` (`UserID`, `Username`, `Password`, `FirstName`, `LastName`, `CreatedBy`, `CreatedDate`, `Modifiedby`, `ModifiedDate`) VALUES
(1, 'user1', 'MTIzNA==', 'Adrian', 'Alcantara', 0, '2020-10-08 06:44:41', 14, '2020-10-08 06:44:41'),
(14, 'Admin', 'QWRtaW4=', 'Admin', 'Admin', 1, '2020-10-24 22:48:22', NULL, '2020-10-24 22:48:22'),
(15, 'Miggy', 'TWlndWVs', 'Miguel', 'Emmanuel', 14, '2020-10-25 01:14:15', NULL, '2020-10-25 01:14:15'),
(17, 'user2', 'MTIzNA==', 'Miguel', 'Fernandez', 14, '2020-10-25 03:51:25', NULL, '2020-10-25 03:51:25'),
(18, 'user3', 'dXNlcjM=', 'Miggy', 'Fernandez', 14, '2020-10-25 04:03:55', NULL, '2020-10-25 04:03:55');

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
  `Quantity` int(11) NOT NULL,
  `PaymentMethod` varchar(100) NOT NULL,
  `Total_Amount` varchar(100) NOT NULL,
  `CardNumber` int(11) DEFAULT NULL,
  `CardOwner` varchar(100) DEFAULT NULL,
  `PaymentNetwork` varchar(100) DEFAULT NULL,
  `CreatedByID` int(11) DEFAULT NULL,
  `CreatedDate` timestamp NOT NULL DEFAULT current_timestamp(),
  `LastModifiedByID` int(11) DEFAULT NULL,
  `LastModifiedDate` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `transactionrecords`
--

INSERT INTO `transactionrecords` (`TransactionID`, `PatientID`, `TransactionDate`, `ProductID`, `NVBSPNumber`, `Quantity`, `PaymentMethod`, `Total_Amount`, `CardNumber`, `CardOwner`, `PaymentNetwork`, `CreatedByID`, `CreatedDate`, `LastModifiedByID`, `LastModifiedDate`) VALUES
(14, 10, '2020-10-27 01:04:48', 1, 13, 1, 'Cash', '$1,500.00', 0, '', '', 14, '2020-10-25 01:10:32', NULL, '2020-10-25 01:10:32'),
(15, 10, '2020-10-25 01:40:31', 2, 6, 1, 'Cash', '$1,500.00', 0, '', '', 14, '2020-10-25 01:46:11', 14, '2020-10-25 02:19:02'),
(16, 10, '2020-10-27 03:42:29', 1, 18, 1, 'Cash', '$1,500.00', 0, '', '', 14, '2020-10-25 03:47:55', NULL, '2020-10-25 03:47:55'),
(17, 10, '2020-10-28 03:56:07', 2, 6, 1, 'Cash', '$1,500.00', 0, '', '', 14, '2020-10-25 04:02:31', 14, '2020-10-25 04:03:19');

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
-- Indexes for table `patient`
--
ALTER TABLE `patient`
  ADD PRIMARY KEY (`PatientID`),
  ADD KEY `AddedByID` (`AddedByID`,`LastModifiedByID`);

--
-- Indexes for table `stock_in`
--
ALTER TABLE `stock_in`
  ADD PRIMARY KEY (`NVBSPNumber`),
  ADD KEY `ProductID` (`ProductID`),
  ADD KEY `SerialNumber` (`NVBSPNumber`),
  ADD KEY `AddedByID` (`AddedByID`);

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
  MODIFY `logID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=321;

--
-- AUTO_INCREMENT for table `bloodproduct`
--
ALTER TABLE `bloodproduct`
  MODIFY `ProductID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=49;

--
-- AUTO_INCREMENT for table `donations`
--
ALTER TABLE `donations`
  MODIFY `DonationID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT for table `donor`
--
ALTER TABLE `donor`
  MODIFY `DonorID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=45;

--
-- AUTO_INCREMENT for table `patient`
--
ALTER TABLE `patient`
  MODIFY `PatientID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=24;

--
-- AUTO_INCREMENT for table `stock_in`
--
ALTER TABLE `stock_in`
  MODIFY `NVBSPNumber` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT for table `tbluser`
--
ALTER TABLE `tbluser`
  MODIFY `UserID` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- AUTO_INCREMENT for table `transactionrecords`
--
ALTER TABLE `transactionrecords`
  MODIFY `TransactionID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
