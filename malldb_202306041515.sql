--
-- Скрипт сгенерирован Devart dbForge Studio 2020 for MySQL, Версия 9.0.391.0
-- Домашняя страница продукта: http://www.devart.com/ru/dbforge/mysql/studio
-- Дата скрипта: 04.06.2023 15:15:20
-- Версия сервера: 8.0.32
-- Версия клиента: 4.1
--

-- 
-- Отключение внешних ключей
-- 
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;

-- 
-- Установить режим SQL (SQL mode)
-- 
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

--
-- Установка базы данных по умолчанию
--
USE malldb;

--
-- Удалить таблицу `tbl_stat`
--
DROP TABLE IF EXISTS tbl_stat;

--
-- Удалить таблицу `tbl_cardhall`
--
DROP TABLE IF EXISTS tbl_cardhall;

--
-- Удалить таблицу `tbl_hall`
--
DROP TABLE IF EXISTS tbl_hall;

--
-- Удалить таблицу `tbl_pavilion`
--
DROP TABLE IF EXISTS tbl_pavilion;

--
-- Удалить таблицу `tbl_rooms`
--
DROP TABLE IF EXISTS tbl_rooms;

--
-- Установка базы данных по умолчанию
--
USE malldb;

--
-- Создать таблицу `tbl_rooms`
--
CREATE TABLE tbl_rooms (
  IdRoom int NOT NULL AUTO_INCREMENT,
  RoomName varchar(255) DEFAULT NULL,
  PRIMARY KEY (IdRoom)
)
ENGINE = INNODB,
AUTO_INCREMENT = 10,
AVG_ROW_LENGTH = 2730,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci;

--
-- Создать таблицу `tbl_pavilion`
--
CREATE TABLE tbl_pavilion (
  Idpav int NOT NULL AUTO_INCREMENT,
  PavName varchar(255) DEFAULT NULL,
  PavOwner varchar(255) DEFAULT NULL,
  PavMenag varchar(255) DEFAULT NULL,
  PavTeleph varchar(255) DEFAULT NULL,
  PavMail varchar(255) DEFAULT NULL,
  PavAdre varchar(255) DEFAULT NULL,
  PavTitle varchar(255) DEFAULT NULL,
  PavStatistic int DEFAULT NULL,
  PRIMARY KEY (Idpav)
)
ENGINE = INNODB,
AUTO_INCREMENT = 110,
AVG_ROW_LENGTH = 3276,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci;

--
-- Создать индекс `FK_tbl_pavilion_tbl_graf_IdGraf` для объекта типа таблица `tbl_pavilion`
--
ALTER TABLE tbl_pavilion
ADD INDEX FK_tbl_pavilion_tbl_graf_IdGraf (PavStatistic);

--
-- Создать таблицу `tbl_hall`
--
CREATE TABLE tbl_hall (
  IdHall int NOT NULL AUTO_INCREMENT,
  HallSide varchar(255) DEFAULT NULL,
  PRIMARY KEY (IdHall)
)
ENGINE = INNODB,
AUTO_INCREMENT = 10,
AVG_ROW_LENGTH = 3276,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci;

--
-- Создать таблицу `tbl_cardhall`
--
CREATE TABLE tbl_cardhall (
  IdCard int NOT NULL AUTO_INCREMENT,
  CardPav int DEFAULT NULL,
  CardHall int DEFAULT NULL,
  CardRoom int DEFAULT NULL,
  CardStat int DEFAULT NULL,
  PRIMARY KEY (IdCard)
)
ENGINE = INNODB,
AUTO_INCREMENT = 71,
AVG_ROW_LENGTH = 3276,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci;

--
-- Создать индекс `FK_tbl_cardhall_tbl_stat_IdStat` для объекта типа таблица `tbl_cardhall`
--
ALTER TABLE tbl_cardhall
ADD INDEX FK_tbl_cardhall_tbl_stat_IdStat (CardStat);

--
-- Создать внешний ключ
--
ALTER TABLE tbl_cardhall
ADD CONSTRAINT FK_tbl_cardhall_tbl_hall_IdHall FOREIGN KEY (CardHall)
REFERENCES tbl_hall (IdHall);

--
-- Создать внешний ключ
--
ALTER TABLE tbl_cardhall
ADD CONSTRAINT FK_tbl_cardhall_tbl_pavilion_Idpav FOREIGN KEY (CardPav)
REFERENCES tbl_pavilion (Idpav);

--
-- Создать внешний ключ
--
ALTER TABLE tbl_cardhall
ADD CONSTRAINT FK_tbl_cardhall_tbl_rooms_IdRoom FOREIGN KEY (CardRoom)
REFERENCES tbl_rooms (IdRoom);

--
-- Создать таблицу `tbl_stat`
--
CREATE TABLE tbl_stat (
  IdStat int NOT NULL AUTO_INCREMENT,
  StatProf int DEFAULT NULL,
  StatLoss int DEFAULT NULL,
  StatData date DEFAULT NULL,
  StatCardID int DEFAULT NULL,
  PRIMARY KEY (IdStat)
)
ENGINE = INNODB,
AUTO_INCREMENT = 20,
AVG_ROW_LENGTH = 5461,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci;

--
-- Создать внешний ключ
--
ALTER TABLE tbl_stat
ADD CONSTRAINT FK_tbl_stat_tbl_cardhall_CardStat FOREIGN KEY (StatCardID)
REFERENCES tbl_cardhall (CardStat);

-- 
-- Вывод данных для таблицы tbl_rooms
--
INSERT INTO tbl_rooms VALUES
(2, 'Р¤СѓРґРєРѕСЂС‚'),
(3, 'РЎРєР»Р°Рґ'),
(4, 'РљРѕРјРЅР°С‚Р° Р°РґРјРёРЅРёСЃС‚СЂР°С†РёРё'),
(5, 'РљРѕРјРЅР°С‚Р° РѕС…СЂР°РЅС‹'),
(6, 'РўРѕС‡РєР° РїСЂРѕРґР°Р¶Рё'),
(7, 'РљРѕРјРЅР°С‚Р° СЃРѕС‚СЂСѓРґРЅРёРєРѕРІ'),
(8, 'РЈР±РѕСЂРЅР°СЏ');

-- 
-- Вывод данных для таблицы tbl_pavilion
--
INSERT INTO tbl_pavilion VALUES
(1, 'РћРґРµР¶РґР°', 'РћСЃР»РёРєРѕРІ Р.Рђ.', 'РџРµС‚СЂРѕРІ РҐ.Р .', '+7 (423) 250-02-1533', 'gjgf@gmail', 'СѓР». Р’РµСЂР·РёРЅР° РґРѕРј 38 РєР°Р±Р±РёРЅРµС‚ 92', '"Р­Р»РµРѕРЅРѕСЂР°"', 1),
(2, 'РћР±СѓРІСЊ', 'РџС‡С‘Р»РєРёРЅ Р‘.Р—.', 'РџР»Р°С€РµРІ Р­.Р›.', '8 800 555 35 35', 'pipipupu@gmail', 'СѓР». РЈР»РёС‡РЅР°СЏ РґРѕРј 237 РєР°Р±РёРЅРµС‚ 92', '"РљРµС„С‚РµРјРµ"', 2),
(3, 'РџРѕРґР°СЂРєРё', 'РљРѕСЂРѕРІРёРЅР° Рњ.РЈ.', 'РЁРѕС‚РіР°РЅ РЁ.Р‘.', '(423) 243-22-42', 'devo4kawensday@gmail', 'СѓР». Р›РѕРјРѕРЅРѕСЃРѕРІР° РґРѕРј 34 РєР°Р±РјРЅРµС‚ 6 ', '"РџРѕР·РґСЂР°РІРѕРє"', 3),
(4, 'Р¤СѓРґРєРѕСЂС‚', 'РџРёСЂР°С‚РєРёРЅ Рђ.Р .', 'Р‘РѕС‡РєРёРЅ Р”.Р.', '+7 (994) 222-97-10', 'ukpook@gmail', 'СѓР». РџСЂС‹С‚РёРЅР° РґРѕРј 10 РєР°Р±РёРЅРµС‚ 1119', '"РЁРёС„Р°РЅСЊРєР°"', 4),
(5, 'РћС…СЂР°РЅР°', 'Р“СЂР°РЅРёРЅ Рћ.Рћ.', 'РљР°РјРЅРµРІ Рљ.Р“.', '+7 902 481-33-33', 'gigachad@gmail', 'СѓР». РўСѓРїРёРє РЅР°РґРµР¶РґС‹ РґРѕРј 99 РєР°Р±РёРЅРµС‚ 84', 'Р±РµР· РЅР°Р·РІР°РЅРёСЏ', 5),
(7, 'РџР°СЂРёРєРјР°С…РµСЂСЃРєР°СЏ', 'РЎРјРѕР»РёРЅР° Рў.Р’.', 'Р›СѓРіРёРЅ Р•.Рў.', '+7 984 145-41-76\r\n', 'phooga@gmail', 'СѓР». Р›СѓС†РєРѕРіРѕ 16 РґРѕРј 6 РєР°Р±РёРЅРµС‚ 6', '"РќР°С‚Р°Р»СЊСЏ"', NULL),
(8, 'Р¤РёС‚РЅРµСЃРєР»СѓР±', 'РђР±СЂР°РјРѕРІ Р›.Р”.', 'РЎРїРѕР»РѕС…РѕРІ Р .Р®.', '+7 (423) 200-02-14', 'nogivonyaut@gmail', 'СѓР». РЎРІРµС‚Р»Р°РЅСЃРєР°СЏ РґРѕРј 114 РєР°Р±РёРЅРµС‚ 23', '"РђС‚Р»РµС‚"', NULL),
(10, 'РўРєР°РЅРё', 'РќР°РІС†РµРІР° Рљ.Р.', 'РўСЂР°Р±РёРЅР° Рђ.Рђ.', '+7 (423) 206-03-26', 'erenyeger@gmail.com', 'СѓР». Р”РѕР±СЂРѕРІРѕР»СЊСЃРєРѕРіРѕ РґРѕРј 20 РєР°Р±РёРЅРµС‚ 2', '"РќРёС‚РѕС‡РєР°"', NULL),
(11, 'РўРµС…РЅРёРєР°', 'РќРµС‡Р°РµРІ РЎ.Рў.', 'Р§Р°С‚РєРѕРІ Р•.Р.', '+7 (423) 272-17-21', 'grmoroy@gmail', 'СѓР». Р’РёР»РєРѕРІР° РґРѕРј 14Р° РєР°Р±РёРЅРµС‚ 122', '"РљРёР±РµСЂС‚СЂРѕРЅ"', NULL),
(12, 'Р”РµС‚СЃРєРёР№', 'РљСЂСѓРїРёРЅР° Рќ.Р¤.', 'Р¤СЂРѕР»РѕРІР° РЈ.Рџ.', '+7 962 838-56-98', 'traktor@gmail', 'СѓР». РљРёСЂРѕРІР° РґРѕРј 36 РєР°Р±РёРЅРµС‚ 43', '"РљР°СЂР°РїСѓР·"', NULL),
(28, 'РљР°Р»СЊСЏРЅР°СЏ', 'РќР°С‚Р°СЂСЊРµРІ Рџ.Р›.', 'РќРѕРІРёРєРѕРІ Р”.Р”.', '+7 916 710-85-55', 'eojrop@gmail.com', 'СѓР». РћРєРµР°РЅСЃРєР°СЏ РґРѕРј 34 РєР°Р±РёРЅРµС‚ 2 ', '"РЎСѓР»С‚Р°РЅ"', NULL),
(105, 'РћС…СЂР°РЅР°', 'Р‘СѓР±Р»РёРє Рџ.Рџ.', 'РѕСЂС‰С€СЂС‰', '465456', NULL, NULL, 'Р‘РµР· РЅР°Р·РІР°РЅРёСЏ', NULL),
(106, 'Р°СЂРІ', 'РїРїРІРїРІР°', NULL, NULL, NULL, NULL, 'СЂСЂР°РІ', NULL),
(107, 'РѕРјСЂРјРіРЅ', NULL, 'РіР°РЅ', NULL, NULL, NULL, 'РёСЂРёРёРёРёРі', NULL),
(108, 'С€РіРїС€РїРіС€Рї', NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(109, 'РµРєС‚РєС‚', NULL, NULL, NULL, NULL, NULL, 'Сѓ', NULL);

-- 
-- Вывод данных для таблицы tbl_hall
--
INSERT INTO tbl_hall VALUES
(1, 'Р—Р°РїР°РґРЅС‹Р№'),
(2, 'РЎРµРІРµСЂРЅС‹Р№'),
(3, 'Р’РѕСЃС‚РѕС‡РЅС‹Р№'),
(4, 'Р¦РµРЅС‚СЂР°Р»СЊРЅС‹Р№'),
(5, 'Р®Р¶РЅС‹Р№');

-- 
-- Вывод данных для таблицы tbl_cardhall
--
INSERT INTO tbl_cardhall VALUES
(1, 1, 3, 6, 1),
(2, 2, 5, 6, 1),
(3, 3, 1, 6, 2),
(4, 4, 2, 2, 2),
(5, 5, 4, 6, 2),
(6, 11, 1, 6, 2),
(7, 10, 3, 6, 1),
(66, 105, 2, 6, 2);

-- 
-- Вывод данных для таблицы tbl_stat
--
INSERT INTO tbl_stat VALUES
(2, 3135, 165164, '2023-05-17', 1),
(3, 48948, 6222, '2023-05-30', 1),
(4, 5000, 625, '2023-05-17', 2),
(5, 3332, 3332, '2023-05-30', 1),
(6, 266511, 4616, '2023-03-28', 2);

-- 
-- Восстановить предыдущий режим SQL (SQL mode)
--
/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;

-- 
-- Включение внешних ключей
-- 
/*!40014 SET FOREIGN_KEY_CHECKS = @OLD_FOREIGN_KEY_CHECKS */;