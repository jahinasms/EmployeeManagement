
===================================================== Employee Table ==============================
CREATE DATABASE employee;

CREATE TABLE `employee` (
  `emp_id` int NOT NULL AUTO_INCREMENT,
  `emp_name` varchar(45) DEFAULT NULL,
  `emp_dob` date DEFAULT NULL,
  `emp_email` varchar(45) DEFAULT NULL,
  `emp_phone` varchar(12) DEFAULT NULL,
  `emp_address` varchar(45) DEFAULT NULL,
  `emp_gender` varchar(10) DEFAULT NULL,
  `emp_role` varchar(45) DEFAULT NULL,
  `emp_salary` varchar(30) DEFAULT NULL,
  `emp_pf_salary` int DEFAULT NULL,
  `emp_gross_salary` int DEFAULT NULL,
  `emp_monthly_salary` int DEFAULT NULL,
  `emp_adharcard_number` varchar(20) DEFAULT NULL,
  `emp_image` blob,
  `dep_id` int DEFAULT NULL,
  PRIMARY KEY (`emp_id`),
  KEY `fk_employee_department` (`dep_id`),
  CONSTRAINT `fk_employee_department` FOREIGN KEY (`dep_id`) REFERENCES `department` (`dep_id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

=============================================== Department Table ==============================

CREATE TABLE employee.`department` (
  `dep_id` int NOT NULL AUTO_INCREMENT,
  `dep_name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`dep_id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

======================================= Employee Attendance Table ===================================

CREATE TABLE employee.`employee_attendance` (
  `id` int NOT NULL AUTO_INCREMENT,
  `emp_id` int DEFAULT NULL,
  `day` varchar(20) DEFAULT NULL,
  `attendance_date` date NOT NULL,
  `check_in` time DEFAULT NULL,
  `check_out` time DEFAULT NULL,
  `status` enum('Present','Absent','Leave') DEFAULT 'Present',
  PRIMARY KEY (`id`),
  KEY `emp_id` (`emp_id`),
  CONSTRAINT `employee_attendance_ibfk_1` FOREIGN KEY (`emp_id`) REFERENCES `employee` (`emp_id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

================================================  Recent Activites Table ===============================
CREATE TABLE employee.`recent_activities` (
  `id` int NOT NULL AUTO_INCREMENT,
  `emp_id` int DEFAULT NULL,
  `activity` varchar(255) DEFAULT NULL,
  `activity_time` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `emp_id` (`emp_id`),
  CONSTRAINT `recent_activities_ibfk_1` FOREIGN KEY (`emp_id`) REFERENCES `employee` (`emp_id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

================================================ Users Table =============================
CREATE DATABASE users;
CREATE TABLE `users` (
  `user_id` int NOT NULL AUTO_INCREMENT,
  `user_name` varchar(50) NOT NULL,
  `user_password` varchar(255) NOT NULL,
  `user_role` varchar(45) NOT NULL,
  PRIMARY KEY (`user_id`),
  UNIQUE KEY `user_name` (`user_name`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
