CREATE TABLE `posts`.`posts` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `body` LONGTEXT NOT NULL,
  `title` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`id`));