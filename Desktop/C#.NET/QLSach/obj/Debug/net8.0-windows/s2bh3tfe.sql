CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

CREATE TABLE `Books` (
    `id` integer NOT NULL,
    `name` text NOT NULL,
    CONSTRAINT `PK_Books` PRIMARY KEY (`id`)
);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20241007082538_InitialDatabase', '8.0.8');

COMMIT;

START TRANSACTION;

CREATE TABLE `Authors` (
    `id` integer NOT NULL,
    `name` text NOT NULL,
    `description` text NOT NULL,
    CONSTRAINT `PK_Authors` PRIMARY KEY (`id`)
);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20241012110723_test', '8.0.8');

COMMIT;

