CREATE DATABASE Snappet
	CHARACTER SET utf8
	COLLATE utf8_general_ci;

-- 
-- Set character set the client will use to send SQL statements to the server
--
SET NAMES 'utf8';

--
-- Set default database
--
USE Snappet;

--
-- Create table "Students"
--
CREATE TABLE Students (
  SubmittedAnswerId INT(11) NOT NULL DEFAULT 0,
  SubmitDateTime DATETIME DEFAULT NULL,
  Correct TINYINT(4) DEFAULT NULL,
  Progress INT(11) DEFAULT NULL,
  UserId INT(11) DEFAULT NULL,
  ExerciseId INT(11) DEFAULT NULL,
  Difficulty DOUBLE DEFAULT NULL,
  Subject VARCHAR(150) DEFAULT NULL,
  ClassDomain VARCHAR(150) DEFAULT NULL,
  LearningObjective VARCHAR(150) DEFAULT NULL,
  PRIMARY KEY (SubmittedAnswerId)
)
ENGINE = INNODB
AVG_ROW_LENGTH = 130
CHARACTER SET utf8
COLLATE utf8_general_ci;

-- 
-- Set character set the client will use to send SQL statements to the server
--
SET NAMES 'utf8';

--
-- Set default database
--
USE Snappet;

DELIMITER $$

--
-- Create procedure "spStudentsReport"
--
CREATE DEFINER = 'root'@'localhost'
PROCEDURE spStudentsReport(IN filterDate VARCHAR(150), IN filterSubject VARCHAR(150), IN filterDomain VARCHAR(150), IN filterRange INT)
BEGIN

  IF filterSubject = '' then 
    SET @subject="%";
 
  ELSE
    SET @subject=filterSubject;
 
  END IF;

  IF filterDomain = '' then 
    SET @domain="%";
 
  ELSE
    SET @domain=filterDomain;
 
  END IF;

  IF filterRange IS NULL then
    SET @range = 100;
  ELSE
    SET @range=filterRange;
  END IF;

SELECT
  *
FROM (SELECT
    UserId,
    Subject,
    ClassDomain,
    LearningObjective,
    COUNT(*) AS TotalExercises,
    SUM(CASE WHEN Correct = 1 THEN 1 ELSE 0 END) AS Correct,
    SUM(CASE WHEN Correct = 0 THEN 1 ELSE 0 END) AS Wrong,
    ROUND(100 * (SUM(CASE WHEN Correct = 1 THEN 1 ELSE 0 END) / COUNT(*)), 2) AS Accuracy
  FROM Students
  WHERE date (SubmitDateTime) = filterDate
  AND Subject LIKE @subject
  AND ClassDomain LIKE @domain
  -- and (ClassDomain = fiterDomain OR filterDomain IS NULL)
  GROUP BY UserId,
           Subject,
           ClassDomain,
           LearningObjective
  ORDER BY ROUND(100 * (SUM(CASE WHEN Correct = 1 THEN 1 ELSE 0 END) / COUNT(*)), 2) DESC, UserId ASC, Subject ASC, ClassDomain ASC) AS Temp
WHERE Temp.Accuracy <= @range;

END
$$

DELIMITER ;