-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 11-06-2022 a las 05:33:17
-- Versión del servidor: 10.4.24-MariaDB
-- Versión de PHP: 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `sofkau`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `categories`
--

CREATE TABLE `categories` (
  `Id` int(11) NOT NULL,
  `Name` longtext NOT NULL,
  `Difficulty` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `categories`
--

INSERT INTO `categories` (`Id`, `Name`, `Difficulty`) VALUES
(1, 'FACIL', '1'),
(2, 'INTERMEDIO', '2'),
(3, 'MEDIO', '3'),
(4, 'PROFESIONAL', '4'),
(5, 'EXPERTO', '5');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `history`
--

CREATE TABLE `history` (
  `Id` int(11) NOT NULL,
  `Score` int(11) NOT NULL,
  `PlayerId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `options`
--

CREATE TABLE `options` (
  `Id` int(11) NOT NULL,
  `Name` longtext NOT NULL,
  `Iscorrect` tinyint(1) NOT NULL,
  `QuestionsId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `options`
--

INSERT INTO `options` (`Id`, `Name`, `Iscorrect`, `QuestionsId`) VALUES
(1, 'mamífero', 1, 1),
(2, 'anfibios', 0, 1),
(3, 'reptiles', 0, 1),
(4, 'cefalópodos', 0, 1),
(5, '300', 0, 2),
(6, '150', 0, 2),
(7, '200', 0, 2),
(8, '206', 1, 2),
(9, 'ácido, salado, frutoso, verdura y tierroso', 0, 3),
(10, 'dulce, amargo, ácido, salado y umami', 1, 3),
(11, 'venenoso, frutoso, dulce, baboso y umami', 0, 3),
(12, 'amargo, salado, aceitoso, tierroso y empalagoso', 0, 3),
(13, 'España', 0, 4),
(14, 'Canada', 0, 4),
(15, 'antártida', 1, 4),
(16, 'Rusia', 0, 4),
(17, 'Diana', 0, 5),
(18, 'Maria isabel V', 0, 5),
(19, 'Tereza de calcuta', 0, 5),
(20, 'Isabel II', 1, 5),
(21, 'Mongolia', 0, 6),
(22, 'Roma', 0, 6),
(23, 'Grecia', 1, 6),
(24, 'Italia', 0, 6),
(25, '1920', 0, 7),
(26, '1945', 1, 7),
(27, '1900', 0, 7),
(28, '1917', 0, 7),
(29, 'Miguel de Cervantes', 1, 8),
(30, 'Gabriel garcia marquez', 0, 8),
(31, 'J. K. Rowling', 0, 8),
(32, 'Edgar Allan Poe', 0, 8),
(33, 'Vincent van Gogh', 0, 9),
(34, 'Frida Kahlo', 0, 9),
(35, 'Leonardo da Vinci', 1, 9),
(36, 'Fernando Botero', 0, 9),
(37, 'Carl Jung', 0, 10),
(38, 'Alfred Adler', 0, 10),
(39, 'Charcot', 0, 10),
(40, 'Sigmund Freud', 1, 10),
(41, 'Elvis Presley', 1, 11),
(42, 'Jimi hendrix', 0, 11),
(43, 'Carlos santana', 0, 11),
(44, 'Jerry Lee Lewis', 0, 11),
(45, 'Es la ciencia que estudia los mares', 0, 12),
(46, 'Es la ciencia que estudia los mapas', 1, 12),
(47, 'Es la ciencia que estudia los animales', 0, 12),
(48, 'Es la ciencia que estudia la tierra', 0, 12),
(49, 'China', 0, 13),
(50, 'Noruega', 0, 13),
(51, 'Italia', 0, 13),
(52, 'París', 1, 13),
(53, 'La Tierra', 1, 14),
(54, 'Venus', 0, 14),
(55, 'Jupiter', 0, 14),
(56, 'Mercurio', 0, 14),
(57, 'España', 0, 15),
(58, 'Francia', 0, 15),
(59, 'Ecuador', 0, 15),
(60, 'Italia', 1, 15),
(61, '6 patas', 0, 16),
(62, '10 patas', 0, 16),
(63, '8 patas', 1, 16),
(64, '4 patas', 0, 16),
(65, 'Tigre', 0, 17),
(66, 'Guepardo', 1, 17),
(67, 'Tortuga', 0, 17),
(68, 'Leon', 0, 17),
(69, 'Mir', 1, 18),
(70, 'NASA', 0, 18),
(71, 'FBI', 0, 18),
(72, 'CTI', 0, 18),
(73, 'El gato', 0, 19),
(74, 'El avestruz', 0, 19),
(75, 'Los Pingüinos', 0, 19),
(76, 'El murciélago', 1, 19),
(77, 'Chile', 1, 20),
(78, 'Argentina', 0, 20),
(79, 'Paraguay', 0, 20),
(80, 'Uruguay', 0, 20),
(81, 'Judas tadeo', 0, 21),
(82, 'Judas iscariote', 1, 21),
(83, 'San pedro', 0, 21),
(84, 'Francisco', 0, 21),
(85, 'Rusia', 0, 22),
(86, 'China', 0, 22),
(87, 'Japón', 1, 22),
(88, 'Ucrania', 0, 22),
(89, 'Azulejo', 0, 23),
(90, 'Maria mulata', 0, 23),
(91, 'Loros', 0, 23),
(92, 'Cuervo', 1, 23),
(93, '1 corazones', 0, 24),
(94, '3 corazones', 1, 24),
(95, '4 corazones', 0, 24),
(96, '2 corazones', 0, 24),
(97, 'Venezuela', 0, 25),
(98, 'Colombia', 0, 25),
(99, 'Etiopía', 1, 25),
(100, 'España', 0, 25);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `players`
--

CREATE TABLE `players` (
  `Id` int(11) NOT NULL,
  `Username` varchar(255) NOT NULL,
  `Password` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `questions`
--

CREATE TABLE `questions` (
  `Id` int(11) NOT NULL,
  `Name` longtext NOT NULL,
  `Score` int(11) NOT NULL,
  `CategoriesId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `questions`
--

INSERT INTO `questions` (`Id`, `Name`, `Score`, `CategoriesId`) VALUES
(1, '¿Qué tipo de animal es la ballena?', 2, 1),
(2, '¿Qué cantidad de huesos hay en el cuerpo humano?', 2, 1),
(3, '¿Cuáles son los cinco tipos de sabores primarios?', 2, 1),
(4, '¿Cuál es el lugar más frío de la tierra?', 2, 1),
(5, '¿Cómo se llama la Reina del Reino Unido?', 2, 1),
(6, '¿Dónde originaron los juegos olímpicos?', 3, 2),
(7, '¿Cuándo acabó la II Guerra Mundial?', 3, 2),
(8, '¿Quién es el autor de el Quijote?', 3, 2),
(9, '¿Quién pintó “la última cena”?', 3, 2),
(10, '¿Quién es el padre del psicoanálisis?', 3, 2),
(11, '¿Quién es el famoso Rey de Rock en los Estados Unidos?', 4, 3),
(12, '¿Qué es la cartografía?', 4, 3),
(13, '¿Dónde se encuentra la famosa Torre Eiffel?', 4, 3),
(14, '¿Cuál es tercer planeta en el sistema solar?', 4, 3),
(15, '¿Qué país tiene forma de bota?', 4, 3),
(16, '¿Cuántas patas tiene la araña?', 5, 4),
(17, '¿Cómo se llama el animal más rápido del mundo?', 5, 4),
(18, '¿Cómo se llama la estación espacial rusa?', 5, 4),
(19, '¿Cuál es el único mamífero capaz de volar?', 5, 4),
(20, '¿Cuál es la nacionalidad de Pablo Neruda?', 5, 4),
(21, '¿Quién traicionó a Jesús?', 6, 5),
(22, '¿En qué país se usó la primera bomba atómica en combate?', 6, 5),
(23, '¿Cuál es el animal que tiene mayor facilidad para repetir las frases y palabras que escucha?', 6, 5),
(24, '¿Cuántos corazones tienen los pulpos?', 6, 5),
(25, '¿De qué país es originario el café?', 6, 5);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20220610142425_firts', '6.0.5');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `categories`
--
ALTER TABLE `categories`
  ADD PRIMARY KEY (`Id`);

--
-- Indices de la tabla `history`
--
ALTER TABLE `history`
  ADD PRIMARY KEY (`Id`);

--
-- Indices de la tabla `options`
--
ALTER TABLE `options`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Options_QuestionsId` (`QuestionsId`);

--
-- Indices de la tabla `players`
--
ALTER TABLE `players`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `Idx_username_players` (`Username`);

--
-- Indices de la tabla `questions`
--
ALTER TABLE `questions`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Questions_CategoriesId` (`CategoriesId`);

--
-- Indices de la tabla `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `categories`
--
ALTER TABLE `categories`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de la tabla `history`
--
ALTER TABLE `history`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `options`
--
ALTER TABLE `options`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=101;

--
-- AUTO_INCREMENT de la tabla `players`
--
ALTER TABLE `players`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `questions`
--
ALTER TABLE `questions`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=26;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `options`
--
ALTER TABLE `options`
  ADD CONSTRAINT `FK_Options_Questions_QuestionsId` FOREIGN KEY (`QuestionsId`) REFERENCES `questions` (`Id`) ON DELETE CASCADE;

--
-- Filtros para la tabla `questions`
--
ALTER TABLE `questions`
  ADD CONSTRAINT `FK_Questions_Categories_CategoriesId` FOREIGN KEY (`CategoriesId`) REFERENCES `categories` (`Id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
