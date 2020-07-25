-- MySQL dump 10.13  Distrib 8.0.19, for Win64 (x86_64)
--
-- Host: localhost    Database: electiondb
-- ------------------------------------------------------
-- Server version	8.0.19

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
-- Table structure for table `candidate`
--

DROP TABLE IF EXISTS `candidate`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `candidate` (
  `candidateID` int NOT NULL AUTO_INCREMENT,
  `firstname` varchar(45) DEFAULT NULL,
  `lastname` varchar(45) DEFAULT NULL,
  `middlename` varchar(45) DEFAULT NULL,
  `position` int NOT NULL,
  `party` int NOT NULL,
  `addedBy` int NOT NULL,
  PRIMARY KEY (`candidateID`),
  KEY `fk_candidate_party1_idx` (`party`),
  KEY `fk_candidate_position1_idx` (`position`),
  KEY `fk_candidate_admin1_idx` (`addedBy`),
  CONSTRAINT `fk_candidate_admin1` FOREIGN KEY (`addedBy`) REFERENCES `admin` (`adminID`),
  CONSTRAINT `fk_candidate_party1` FOREIGN KEY (`party`) REFERENCES `party` (`partyID`),
  CONSTRAINT `fk_candidate_position1` FOREIGN KEY (`position`) REFERENCES `position` (`positionID`)
) ENGINE=InnoDB AUTO_INCREMENT=92 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `candidate`
--

LOCK TABLES `candidate` WRITE;
/*!40000 ALTER TABLE `candidate` DISABLE KEYS */;
INSERT INTO `candidate` VALUES (3,'Rodrigo','Duterte','Roa',1,1,1),(4,'Manuel','Roxas','Araneta',1,2,1),(5,'Mary Grace','Llamanzares','Poe',1,3,1),(6,'Jejomar ','Binay','Jojo',1,1,1),(7,'Miriam','Santiago','Defensor',1,2,1),(8,'Alan Peter ','Cayetano','Schramm ',2,3,1),(9,'Francis Joseph','Escudero','Guevara',2,1,1),(10,'Gregorio','Honasan','Ballesteros',2,2,1),(11,'Ferdinand','Marcos','Romualdez',2,3,1),(12,'Maria Leonor','Robredo','Gerona',2,3,1),(13,'Antonio','Trillanes','Fuentes',2,1,1),(14,'Vangie','Abejo','Roche',3,3,1),(15,'Abner','Afuang','Labastida',3,2,1),(16,'Ferdinand','Aguilar','Pascual',3,2,1),(17,'Shariff Ibrahim ','Albani','Hussien',3,2,1),(18,'Gary','Alejano','Calojo',3,3,1),(19,'Richard','Alfora','',3,2,1),(22,'Raffy','Alunan',' ',3,3,1),(23,'Edgardo Sonny','Angara',' ',3,1,1),(24,'Benigno','Aquino',' ',3,2,1),(25,'Gerald','Arcega',' ',3,1,1),(26,'Ernesto','Arrellano',' ',3,3,1),(27,'Marcelino','Arias',' ',3,3,1),(28,'Bernard','Austria',' ',3,2,1),(29,'Balde','Baldevarona',' ',3,1,1),(30,'Nancy','Binay',' ',3,3,1),(31,'Bong','Revilla',' ',3,1,1),(32,'Jesus','Caceres',' ',3,2,1),(33,'Toti','Casiño',' ',3,3,1),(34,'Pia','Cayetano',' ',3,3,1),(35,'Melchor','Chavez',' ',3,2,1),(36,'Glenn','Chong',' ',3,3,1),(37,'Neri','Colmenares',' ',3,1,1),(38,'Ka Leody','De Guzman',' ',3,2,1),(39,'Bato','Dela Rosa',' ',3,3,1),(40,'Chel','Diokno',' ',3,1,1),(41,'JV ','Ejercito',' ',3,2,1),(42,'Juan Ponce','Enrile',' ',3,3,1),(43,'Agnes','Escudero',' ',3,3,1),(44,'Jinggoy','Estrada',' ',3,2,1),(45,'Elmer','Francisco',' ',3,1,1),(46,'Charlie','Gaddi',' ',3,2,1),(47,'Larry','Gadon',' ',3,1,1),(48,'Gen Pederalismo','Generoso',' ',3,2,1),(49,'Bong','Go',' ',3,3,1),(50,'Junbert','Guigayuma',' ',3,1,1),(51,'Samira','Gutoc',' ',3,1,1),(52,'Pilo','Hilbay',' ',3,2,1),(53,'BFG Abraham','Jangao',' ',3,1,1),(54,'RJ','Javellana',' ',3,2,1),(55,'Lito','Lapid',' ',3,2,1),(56,'Macaromy','Macalintal',' ',3,3,1),(57,'Emily','Mallillin',' ',3,3,1),(58,'Faisal','Mangondato',' ',3,3,1),(59,'Dong','Mangudadatu',' ',3,2,1),(60,'Jiggy','Manicad',' ',3,1,1),(61,'Imee','Marcos',' ',3,2,1),(62,'Jose Sonny','Matula',' ',3,3,1),(63,'Luther','Meniano',' ',3,2,1),(64,'Allan','Montaño',' ',3,1,1),(65,'Joan Sheelah','Nalliw',' ',3,2,1),(79,'Doc ','Ong','Willie',3,1,1),(80,'Serge','Osmeña',' ',3,2,1),(81,'Dado','Padilla',' ',3,3,1),(82,'Koko','Pimentel',' ',3,3,1),(83,'Grace','Poe',' ',3,2,1),(84,'Dan ','Roleda','Kaibigan',3,1,1),(85,'Harry ','Roque',' ',3,2,1),(86,'Mar','Roxas',' ',3,2,1),(87,'Lady ','Sahidulla','Ann',3,1,1),(88,'Lorenzo Erin ','Tañada','Tapat',3,3,1),(89,'Francis','Tolentino',' ',3,2,1),(90,'Butch','Valdes',' ',3,1,1),(91,'Cynthia','Villar',' ',3,2,1);
/*!40000 ALTER TABLE `candidate` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-03-22 15:21:15
