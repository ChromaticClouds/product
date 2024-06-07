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
-- Table structure for table `register`
--

DROP TABLE IF EXISTS `register`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `register` (
  `RegisterID` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) NOT NULL,
  `Category` varchar(45) NOT NULL,
  `Description` text,
  `SalePrice` bigint NOT NULL,
  `OriginPrice` bigint DEFAULT NULL,
  `Date` date DEFAULT NULL,
  PRIMARY KEY (`RegisterID`)
) ENGINE=InnoDB AUTO_INCREMENT=49 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `register`
--

LOCK TABLES `register` WRITE;
/*!40000 ALTER TABLE `register` DISABLE KEYS */;
INSERT INTO `register` VALUES (38,'농심 육개장 사발면 * 24개 1세트','가공식품','열량: 300g',1000,1000,'2024-06-04'),(39,'먹태깡 청양마요맛, 60g, 16개','가공식품','총 수량: 16개\n포장 타입: 봉지\n과자 맛: 짭짤한맛\n과자 종류: 봉지과자',22900,24000,'2024-06-04'),(40,'맥심 모카골드 마일드 커피믹스, 12g, 160개입, 1박스','가공식품','맛/향: 초콜릿/모카\n설탕 함량: 설탕첨가\n종류: 커피믹스\n총 수량: 160개',19280,22670,'2024-06-04'),(41,'핫식스 더 킹 크러쉬피치 에너지음료, 355ml, 24개','가공식품','용기 타입: 캔\n설탕 함량: 설탕첨가\n카페인 유형: 카페인\n대용량상품: --- 기타 ---',20200,20690,'2024-06-04'),(42,'오뚜기 맛있는 컵밥 제육덮밥, 310g, 12개','가공식품','섭취방법: 310g\n즉석밥 종류: 쌀밥\n유형: 덮밥/비빔밥\n맛: 약간매운맛',23280,36960,'2024-06-04');
/*!40000 ALTER TABLE `register` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-06-07 13:10:39
