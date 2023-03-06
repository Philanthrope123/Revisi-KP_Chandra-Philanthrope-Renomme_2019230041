-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Feb 22, 2023 at 04:18 AM
-- Server version: 10.1.38-MariaDB
-- PHP Version: 7.3.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_absensikp`
--

-- --------------------------------------------------------

--
-- Table structure for table `tbl_absensi`
--

CREATE TABLE `tbl_absensi` (
  `Tanggal` varchar(30) NOT NULL,
  `Nisn` varchar(30) NOT NULL,
  `Nama_Siswa` varchar(40) NOT NULL,
  `Nama_Sekolah` varchar(40) NOT NULL,
  `Jenis_Kelamin` varchar(10) NOT NULL,
  `Keterangan` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_absensi`
--

INSERT INTO `tbl_absensi` (`Tanggal`, `Nisn`, `Nama_Siswa`, `Nama_Sekolah`, `Jenis_Kelamin`, `Keterangan`) VALUES
('2023-01-05', '201923071', 'Aldiansyah', 'Bina', 'Pria', 'Hadir'),
('2023-01-10', '294945', 'Ari amanto', 'budi', 'Pria', 'Hadir'),
('2023-01-26', '2439043', 'aqil', 'bm', 'Pria', 'Hadir'),
('2023-02-15', '2019230049', 'Ilham Satrio', 'Bina Mandiri', 'Pria', 'Hadir'),
('2023-02-15', '2019230049', 'Ilham Satrio', 'Bina Mandiri', 'Pria', 'Izin '),
('2023-02-15', '2019230069', 'Dimas Gilang', 'Unsada', 'Pria', 'Hadir'),
('17/02/2023 06:02:38', '2019230041', 'Chandra PR', 'Bina Mandiri', 'Pria', 'Hadir'),
('17/02/2023 06:02:38', '2019230041', 'Chandra PR', 'Bina Mandiri', 'Pria', 'Hadir'),
('2023-02-15', '2019230079', 'Fahmi', 'Unsada', 'Pria', 'Hadir'),
('2023-02-15', '2019230079', 'Fahmi', 'Unsada', 'Pria', 'Sakit'),
('16/02/2023 14:16:54', '2019230073', 'Arif R', 'Unsada', 'Pria', 'Sakit'),
('2023-02-16', '201923053', 'Puji', 'Unsada', 'Pria', 'Hadir'),
('2023-02-16', '201923053', 'Puji', 'Unsada', 'Pria', 'Hadir'),
('16/02/2023 20:27:39', '2019230042', 'Faisal Febriansyah', 'Unsada', 'Pria', 'Izin '),
('17/02/2023 06:02:38', '2019230041', 'Chandra PR', 'Bina Mandiri', 'Pria', 'Hadir'),
('2023-02-17', '2019230023', 'Ricky N', 'Unsada', 'Pria', 'Hadir'),
('2023-02-17', '2019230049', 'Ilham Satrio', 'Bina Mandiri', 'Pria', 'Izin '),
('2023-02-17', '2019230059', 'Aditya Febrinsyah', 'Unsada', 'Pria', 'Hadir');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_master`
--

CREATE TABLE `tbl_master` (
  `No` int(10) NOT NULL,
  `NISN` varchar(30) NOT NULL,
  `Nama_Siswa` varchar(40) NOT NULL,
  `Nama_Sekolah` varchar(40) NOT NULL,
  `Jenis_Kelamin` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_master`
--

INSERT INTO `tbl_master` (`No`, `NISN`, `Nama_Siswa`, `Nama_Sekolah`, `Jenis_Kelamin`) VALUES
(1, '2019230050', 'ricky', 'mts', 'Pria'),
(2, '2018230050', 'dwiky', 'bhakti mandiri', 'Pria'),
(3, '2019230041', 'Chandra PR', 'Bina Mandiri', 'Pria'),
(4, '201923071', 'Aldiansyah', 'Bina', 'Pria'),
(5, '294945', 'Ari amanto', 'budi', 'Pria'),
(6, '2439043', 'aqil', 'bm', 'Pria'),
(7, '2019230041', 'Chandra PR', 'Bina Mandiri', 'Pria'),
(8, '2019230049', 'Ilham Satrio', 'Bina Mandiri', 'Pria'),
(9, '2019230049', 'Ilham Satrio', 'Bina Mandiri', 'Pria'),
(10, '2019230059', 'Aditya Febrinsyah', 'Unsada', 'Pria');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_user`
--

CREATE TABLE `tbl_user` (
  `Username` varchar(30) NOT NULL,
  `Password` varchar(30) NOT NULL,
  `Status` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_user`
--

INSERT INTO `tbl_user` (`Username`, `Password`, `Status`) VALUES
('chandra', '123', 'Admin'),
('ratna', '123', 'manajer');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
