-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Oct 01, 2021 at 04:15 PM
-- Server version: 5.5.13
-- PHP Version: 7.2.18

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `bitnovastores`
--

-- --------------------------------------------------------

--
-- Table structure for table `categories`
--

DROP TABLE IF EXISTS `categories`;
CREATE TABLE IF NOT EXISTS `categories` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `categories`
--

INSERT INTO `categories` (`id`, `name`) VALUES
(5, 'Apparels'),
(3, 'Beddings'),
(4, 'Utensils');

-- --------------------------------------------------------

--
-- Table structure for table `company`
--

DROP TABLE IF EXISTS `company`;
CREATE TABLE IF NOT EXISTS `company` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `email` varchar(50) NOT NULL,
  `regno` varchar(50) NOT NULL,
  `icon` blob NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `company`
--

INSERT INTO `company` (`id`, `name`, `email`, `regno`, `icon`) VALUES
(2, 'Bitnova', 'hello@bitnova.co.ke', 'CRTX457', 0xffd8ffe000104a46494600010101004800480000ffe100924578696600004d4d002a000000080005013e0005000000020000004a013f0005000000060000005a511000010000000101000000511100040000000100000b13511200040000000100000b130000000000007a25000186a000008083000186a00000f9ff000186a0000080e9000186a000007530000186a00000ea60000186a000003a98000186a00000176f000186a0ffdb004300080606070605080707070909080a0c140d0c0b0b0c1912130f141d1a1f1e1d1a1c1c20242e2720222c231c1c2837292c30313434341f27393d38323c2e333432ffdb0043010909090c0b0c180d0d1832211c213232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232ffc00011080040004003012200021101031101ffc4001f0000010501010101010100000000000000000102030405060708090a0bffc400b5100002010303020403050504040000017d01020300041105122131410613516107227114328191a1082342b1c11552d1f02433627282090a161718191a25262728292a3435363738393a434445464748494a535455565758595a636465666768696a737475767778797a838485868788898a92939495969798999aa2a3a4a5a6a7a8a9aab2b3b4b5b6b7b8b9bac2c3c4c5c6c7c8c9cad2d3d4d5d6d7d8d9dae1e2e3e4e5e6e7e8e9eaf1f2f3f4f5f6f7f8f9faffc4001f0100030101010101010101010000000000000102030405060708090a0bffc400b51100020102040403040705040400010277000102031104052131061241510761711322328108144291a1b1c109233352f0156272d10a162434e125f11718191a262728292a35363738393a434445464748494a535455565758595a636465666768696a737475767778797a82838485868788898a92939495969798999aa2a3a4a5a6a7a8a9aab2b3b4b5b6b7b8b9bac2c3c4c5c6c7c8c9cad2d3d4d5d6d7d8d9dae2e3e4e5e6e7e8e9eaf2f3f4f5f6f7f8f9faffda000c03010002110311003f00c822961b796e2511c31b3b9e8054f6d6b25ddc2c310cb31fcbdeba09ee2dbc3f6de45ba892e986493fccff00857d763f3074251a1423cd565b2ecbbbec8f9fa555dae5487c3491c7e6ea172b1af755207ea69593c330fca73211dc339fe5c562dd5d4f7721927919dbdfa0fa55cd3743935281a5499102b6dc106b82be1aad3a7edf1f8a9457f73dd4bcb44db3ae33beb2917553c3337ca3319f52ce3f9f14d9fc3092c7e6e9d74b2af65620e7f1158122797232673b4919a7db5ddc59ca24b79591bd8f07ea3bd6ef2dc5525cf85c449bed3f793fd51d518cb784bef239e096da5314d1b238ea185475d6dbdcda7892d4dbdca88eed46548fe63fa8ae66eed65b2b9782618653f811ea2ba701983af2950af1e5ab1dd775dd7746f4eaf33e592b34751a5a269da4cb7f22e5dc7ca3dbb0fc4d73d348f34ad248c59d8e49ae875d3e4e9d696cbc0ee3e83ffaf5cf115cb9247db2a98d97c551bb79456891f2f2a9c8d43b13c16914b0ef6660727814db4d52eec6331dbc8154b6e20a83cd4419d7a311f434e5549396183eddebd1af4e0e2d6212945f46ae6b4aa34db6ee8bd0695fdb30c975032c528621d0fdd27ae41edf4ac9b9b696d67686642aebd4569e91a94d6574b0ae1a192401948f5e322b4bc570298609f1f386284fa8ebfe7eb5e4c31988c2e631c2d5d69cfe1eebcbfafbcf4a95669dba1cb452bc1324b13157439045749aca26aba243a946b89231f381e9d08fc0d7344574be1c3f68d2efad1b91d87d463fa56d9dc7d8aa78d8fc54dabf9c5bb3474d495ad35d09fc423cc82d661d083fa806b008ae8a21fda7a0794399a1e00f71d3f4ae7a96452f67425857f153935f26ee9fccf95c43f794d6cd10c8db31ef429cae7352322b7de00fd6a9dd48f1481630718ec2bd4a8dc24e72d5763af0cd55b538e922dc176d657293a2c6ce87203ae455dd5f585d516111a346a832ca4ff11ebf8565b956b7de48fbb9cd56b5937bb0f6ae19e1693c6c2bc95df4f23be92bd372ec4e45747e181e55b5ece7ee803f404d73f8cd7493aff64786bc93c4f3f047b9ebf90e2b2cfa5ed28470abe2a924be49ddbf91a7b4e68d8a1a6df358dc87e4c6dc3afb568ea7a609d7edb658757e5957bfb8ff000ac2abb63a94f62df21dd19ea87a7ff5ab4c6e0ab7b658bc23b545a34f692ecfcfb33e769d48f2fb3a9b7e452239c1a4ae88cba4ea9ccbfb998f527e53f9f434c6f0eabf30dd82beeb9fe559473da10f7715174e5e69dbe4d6e5ac3cf783ba389d42194dc8585188619200e3356eced4c11fcdcc8dd71fcabaa1e1c55e66bb017d971fccd3c4ba4695cc5fbf987423e63f9f4158acdb0d2a8e5858caac9ec92765f37b1ea3c4d674634a768a5f7b20d2b495b75fb7df61153e6556edee7fc2b2f55bf6d46ecc9c88d7845f41fe3526a1a94f7eff0039db18e91af4ff00eb9acf22baf0382aded9e2f16ef51e892da2bb2f3eec985557d0ffd9);

-- --------------------------------------------------------

--
-- Table structure for table `orders`
--

DROP TABLE IF EXISTS `orders`;
CREATE TABLE IF NOT EXISTS `orders` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `qty` int(50) NOT NULL,
  `category` varchar(50) NOT NULL,
  `supplier` varchar(30) NOT NULL,
  `tdate` varchar(50) NOT NULL,
  `status` varchar(30) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `orders`
--

INSERT INTO `orders` (`id`, `name`, `qty`, `category`, `supplier`, `tdate`, `status`) VALUES
(1, 'Throw Pillows', 60, 'Apparels', 'Peter', '20211001', 'completed'),
(2, 'Throw Pillows', 60, 'Apparels', 'Peter', '20211001', 'live'),
(3, 'Sweat Pants', 40, 'Apparels', 'John Doe', '20211001', 'completed');

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

DROP TABLE IF EXISTS `products`;
CREATE TABLE IF NOT EXISTS `products` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `qty` int(50) NOT NULL,
  `category` varchar(50) NOT NULL,
  `supplier` varchar(100) NOT NULL,
  `tdate` varchar(30) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`id`, `name`, `qty`, `category`, `supplier`, `tdate`) VALUES
(1, 'Pull neck', 8, 'Apparels', 'Peter', '20210930'),
(2, 'Duvet', 50, 'Beddings', 'John Doe', '20210930');

-- --------------------------------------------------------

--
-- Table structure for table `receivedstock`
--

DROP TABLE IF EXISTS `receivedstock`;
CREATE TABLE IF NOT EXISTS `receivedstock` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `qty` int(50) NOT NULL,
  `category` varchar(50) NOT NULL,
  `supplier` varchar(30) NOT NULL,
  `tdate` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `receivedstock`
--

INSERT INTO `receivedstock` (`id`, `name`, `qty`, `category`, `supplier`, `tdate`) VALUES
(1, 'Pull neck', 5, 'Apparels', 'Peter', '20211001'),
(2, 'Pull neck', 21, 'Apparels', 'Peter', '20211001');

-- --------------------------------------------------------

--
-- Table structure for table `suppliers`
--

DROP TABLE IF EXISTS `suppliers`;
CREATE TABLE IF NOT EXISTS `suppliers` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `email` varchar(50) NOT NULL,
  `commodity` varchar(100) NOT NULL,
  `phone` int(30) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `suppliers`
--

INSERT INTO `suppliers` (`id`, `name`, `email`, `commodity`, `phone`) VALUES
(1, 'Peter', 'peter@gmail.com', 'Hoodie', 793467123),
(2, 'John Doe', 'johndoe@gmail.com', 'Duvets', 793567261);

-- --------------------------------------------------------

--
-- Table structure for table `usedstock`
--

DROP TABLE IF EXISTS `usedstock`;
CREATE TABLE IF NOT EXISTS `usedstock` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `qty` int(50) NOT NULL,
  `category` varchar(50) NOT NULL,
  `supplier` varchar(30) NOT NULL,
  `tdate` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `usedstock`
--

INSERT INTO `usedstock` (`id`, `name`, `qty`, `category`, `supplier`, `tdate`) VALUES
(1, 'Pull neck', 5, 'Apparels', 'Peter', '20211001'),
(2, 'Pull neck', 21, 'Apparels', 'Peter', '20211001'),
(3, 'Duvet', 20, 'Beddings', 'John Doe', '20211001'),
(4, 'Pull neck', 22, 'Apparels', 'Peter', '20211001');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
CREATE TABLE IF NOT EXISTS `users` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(100) NOT NULL,
  `email` varchar(50) NOT NULL,
  `role` text NOT NULL,
  `password` text NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `username`, `email`, `role`, `password`) VALUES
(1, 'Peter', 'peter@gmail.com', 'Admin', '12334'),
(2, 'sang', 'sang@gmail.com', 'Admin', '120705DE7E61C5B322AD798B8EF225A7');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
