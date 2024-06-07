-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: localhost    Database: product
-- ------------------------------------------------------
-- Server version	8.0.35

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `products`
--

DROP TABLE IF EXISTS `products`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `products` (
  `ProductID` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) NOT NULL,
  `Category` varchar(255) DEFAULT NULL,
  `Description` text,
  `Price` bigint NOT NULL,
  `Count` int DEFAULT NULL,
  `Status` varchar(45) DEFAULT NULL,
  `InBound` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `RegisterID` int NOT NULL,
  PRIMARY KEY (`ProductID`),
  KEY `ResisterID_idx` (`RegisterID`),
  CONSTRAINT `ResisterID` FOREIGN KEY (`RegisterID`) REFERENCES `register` (`RegisterID`)
) ENGINE=InnoDB AUTO_INCREMENT=44 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products`
--

LOCK TABLES `products` WRITE;
/*!40000 ALTER TABLE `products` DISABLE KEYS */;
INSERT INTO `products` VALUES (39,'농심 육개장 사발면 * 24개 1세트','가공식품','열량: 300g',1000,13,'입고','2024-06-07 23:00:00',38),(40,'농심 육개장 사발면 * 24개 1세트','가공식품','열량: 300g',1000,14,'입고','2024-06-09 00:00:00',38),(41,'먹태깡 청양마요맛, 60g, 16개','가공식품','총 수량: 16개\n포장 타입: 봉지\n과자 맛: 짭짤한맛\n과자 종류: 봉지과자',22900,20,'입고','2024-06-06 00:00:00',39),(42,'농심 육개장 사발면 * 24개 1세트','가공식품','열량: 300g',1000,12,'입고','2024-06-07 23:00:00',38),(43,'핫식스 더 킹 크러쉬피치 에너지음료, 355ml, 24개','가공식품','용기 타입: 캔\n설탕 함량: 설탕첨가\n카페인 유형: 카페인\n대용량상품: --- 기타 ---',20200,5,'입고','2024-06-05 23:00:00',41);
/*!40000 ALTER TABLE `products` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-06-07 13:10:41
