-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Máy chủ: localhost
-- Thời gian đã tạo: Th12 01, 2024 lúc 02:39 PM
-- Phiên bản máy phục vụ: 5.7.25
-- Phiên bản PHP: 7.1.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Cơ sở dữ liệu: `qlsach`
--

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `authors`
--

CREATE TABLE `authors` (
  `Id` int(11) NOT NULL,
  `name` varchar(40) CHARACTER SET utf8 NOT NULL,
  `description` varchar(300) CHARACTER SET utf8 NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `authors`
--

INSERT INTO `authors` (`Id`, `name`, `description`) VALUES
(1, 'Deven', 'Eius officiis harum sed corrupti sapiente illo est.'),
(2, 'Sylvan', 'Repudiandae iusto qui sit vero odit in.'),
(3, 'Jillian', 'Mollitia corrupti aut porro doloremque assumenda dolores dolores voluptas sint.'),
(4, 'Wilbert', 'Sunt magnam et voluptatem.'),
(5, 'Keegan', 'Dolorem voluptas et.'),
(6, 'Sonya', 'Beatae dolore consectetur.'),
(7, 'Valentine', 'Vero ut cupiditate.'),
(8, 'Minnie', 'Sed temporibus nobis eligendi eum et at ipsum quos aspernatur.'),
(9, 'Halie', 'Totam alias voluptatibus aut adipisci fuga occaecati maxime.'),
(10, 'Breanne', 'Quaerat eveniet impedit provident quas.'),
(11, 'Brycen', 'Sint asperiores neque cumque.'),
(12, 'Nat', 'Et dolores esse veritatis quaerat.'),
(13, 'Fabian', 'Commodi odit quae ipsum impedit consequuntur.'),
(14, 'Etha', 'Laudantium aut sit ipsam doloribus ab rerum excepturi mollitia.'),
(15, 'Jazmin', 'Odio cumque itaque porro non nemo.'),
(16, 'Noemie', 'Nobis dolor dolor.'),
(17, 'Noemi', 'Consectetur ad est est quo praesentium esse voluptatum.'),
(18, 'Carlie', 'Inventore velit excepturi ipsum aliquam.'),
(19, 'Muhammad', 'Omnis fugiat tempore ea culpa dolore laborum sit.'),
(20, 'Lucile', 'Ex dolorum porro qui voluptatem.'),
(21, 'Therese', 'Tenetur non et commodi et ex rerum similique officia dolorem.'),
(22, 'Buck', 'Doloribus nostrum et architecto adipisci.'),
(23, 'Pasquale', 'Velit accusantium et aut ullam ipsum.'),
(24, 'Howard', 'Laudantium beatae ut quisquam nihil.'),
(25, 'Mohammed', 'In in numquam quo iure.'),
(26, 'Estrella', 'Provident in harum sunt ut qui voluptas vel.'),
(27, 'Juvenal', 'Maiores vel aliquid.'),
(28, 'Katelynn', 'Et pariatur reiciendis.'),
(29, 'Eve', 'Quo animi est.'),
(30, 'Adrianna', 'Voluptatibus ut qui beatae.'),
(31, 'Merle', 'Est molestiae libero.'),
(32, 'Myrl', 'Dolore rerum architecto modi sed minima laboriosam consequatur.');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `books`
--

CREATE TABLE `books` (
  `Id` int(11) NOT NULL,
  `name` varchar(500) CHARACTER SET utf8 NOT NULL,
  `description` varchar(1000) CHARACTER SET utf8 NOT NULL,
  `author_id` int(11) NOT NULL,
  `genre_id` int(11) NOT NULL,
  `publisher_id` int(11) NOT NULL,
  `photoPath` varchar(100) NOT NULL,
  `rating` float NOT NULL,
  `storage_location` varchar(40) CHARACTER SET utf8 NOT NULL,
  `public_at` date NOT NULL,
  `views` int(11) NOT NULL,
  `quantity` int(11) NOT NULL,
  `remaining` int(11) NOT NULL,
  `created_at` datetime NOT NULL,
  `updated_at` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `books`
--

INSERT INTO `books` (`Id`, `name`, `description`, `author_id`, `genre_id`, `publisher_id`, `photoPath`, `rating`, `storage_location`, `public_at`, `views`, `quantity`, `remaining`, `created_at`, `updated_at`) VALUES
(1, 'consectetur', 'Iure beatae enim vel commodi quia. Quod ut est et eius nam quo esse eius aut. Magni omnis occaecati molestias dolor. Accusamus voluptas officiis libero consequuntur maiores. Quia et consequatur.', 15, 21, 7, '.\\resources\\images\\poster.png', 0, 'T5', '2020-06-07', 0, 6, 1, '2024-12-01 21:38:51', '2024-12-01 21:38:51'),
(2, 'in', 'Molestiae quod rerum debitis et amet alias vitae. Sed hic voluptatum mollitia quas. Magnam deserunt et quam suscipit inventore quasi cum voluptatem. Id unde dolor sit molestiae rem dolorem. Ipsum facilis dolorem officiis atque. Deleniti ut et non dolorum numquam rerum.', 30, 10, 11, '.\\resources\\images\\poster.png', 0, 'D4', '2009-01-25', 0, 5, 3, '2024-12-01 21:38:51', '2024-12-01 21:38:51'),
(3, 'itaque', 'Quisquam vitae asperiores rerum voluptatem labore sint repellat esse sed. Velit at accusantium. Consequatur magni et adipisci corporis reprehenderit aspernatur fugiat inventore. Ea asperiores voluptatum vel qui nesciunt possimus. Voluptatem laborum aut molestiae fugiat nisi ipsam.', 20, 11, 17, '.\\resources\\images\\poster.png', 0, 'Y5', '2002-10-16', 0, 6, 2, '2024-12-01 21:38:51', '2024-12-01 21:38:51'),
(4, 'quod', 'Velit voluptas iure neque deleniti in eveniet sit ut. Culpa aut inventore culpa eaque. Est libero et qui dignissimos et amet. Ut sequi aut. Aut laboriosam et harum reprehenderit cumque.', 1, 12, 12, '.\\resources\\images\\poster.png', 0, 'F5', '2023-09-03', 0, 5, 2, '2024-12-01 21:38:51', '2024-12-01 21:38:51'),
(5, 'voluptatem', 'Illo itaque laborum. Dolorem dolorem est ut maiores autem dolorem nostrum. Vel qui suscipit qui aut. Quae occaecati est ab perspiciatis. Aut alias qui voluptas quo quo quo. Accusamus et cumque numquam numquam.', 7, 32, 30, '.\\resources\\images\\poster.png', 0, 'Y5', '2018-05-24', 0, 5, 2, '2024-12-01 21:38:51', '2024-12-01 21:38:51'),
(6, 'id', 'Quos dolores odio nostrum molestiae enim deserunt. Asperiores vel nobis autem est asperiores. Earum totam quia sapiente tempore sit amet earum. Id repudiandae et doloribus et aliquid est et ad sunt. Architecto aperiam soluta animi veritatis. Porro necessitatibus nobis ab eaque tempore ad ea voluptatem.', 26, 32, 19, '.\\resources\\images\\poster.png', 0, 'L6', '2012-12-06', 0, 6, 3, '2024-12-01 21:38:51', '2024-12-01 21:38:51'),
(7, 'esse', 'Vitae nam consequuntur qui quae ducimus et totam. Vero eligendi occaecati iure et assumenda. Nemo adipisci minima itaque.', 23, 8, 27, '.\\resources\\images\\poster.png', 0, 'F5', '2020-12-23', 0, 9, 0, '2024-12-01 21:38:51', '2024-12-01 21:38:51'),
(8, 'rerum', 'Tempora voluptate dolore sapiente eius cupiditate dolorem excepturi et dolores. Fugit iure amet perspiciatis cum commodi omnis repudiandae placeat. Veniam et enim quia molestiae voluptatem ullam.', 26, 9, 14, '.\\resources\\images\\poster.png', 0, 'T5', '2012-02-11', 0, 5, 1, '2024-12-01 21:38:51', '2024-12-01 21:38:51'),
(9, 'aut', 'Aliquam provident esse est facilis. Asperiores nobis tempore at qui corporis est. Ut nostrum non voluptas.', 32, 8, 12, '.\\resources\\images\\poster.png', 0, 'D4', '2021-12-07', 0, 6, 5, '2024-12-01 21:38:51', '2024-12-01 21:38:51'),
(10, 'dolorem', 'Nisi tenetur quae quod quod voluptates soluta quae. Odio fugiat occaecati. Dolorem distinctio consequatur est velit dolorem omnis officia.', 28, 24, 26, '.\\resources\\images\\poster.png', 0, 'Y5', '2023-08-04', 0, 8, 5, '2024-12-01 21:38:51', '2024-12-01 21:38:51'),
(11, 'dolore', 'Sint fuga quibusdam enim labore harum excepturi delectus. Soluta vel delectus magni. Explicabo maiores perferendis ipsa eligendi accusamus et laudantium fugit. Veniam dolor placeat quaerat voluptatem soluta modi maiores.', 4, 31, 32, '.\\resources\\images\\poster.png', 0, 'F5', '2002-08-22', 0, 9, 2, '2024-12-01 21:38:51', '2024-12-01 21:38:51'),
(12, 'in', 'Tempora rem in quia tenetur deserunt amet ut ipsam. Quos quae aut qui repellendus. Eveniet et et perferendis. Illum ab atque. Soluta unde vel unde fugit officia rerum. Sit et placeat ea necessitatibus quo quasi veniam.', 30, 5, 29, '.\\resources\\images\\poster.png', 0, 'L6', '2023-06-18', 0, 5, 0, '2024-12-01 21:38:51', '2024-12-01 21:38:51'),
(13, 'et', 'Eos omnis earum dolorum beatae corporis reiciendis praesentium ea. Voluptates ut et vel cupiditate veniam eos tempore voluptatem. Voluptatum nam sapiente dolorem eaque. Aspernatur ea eius temporibus possimus officiis explicabo. Libero est molestiae optio sunt sit et. Eos voluptate pariatur vitae nemo eos sunt dolorum accusamus.', 32, 7, 25, '.\\resources\\images\\poster.png', 0, 'Y5', '2017-11-09', 0, 10, 2, '2024-12-01 21:38:51', '2024-12-01 21:38:51'),
(14, 'eveniet', 'Accusantium pariatur repellendus qui similique et. Autem non rerum velit doloremque. Amet sunt fugiat similique nihil. Deleniti nemo est qui ab cupiditate rerum. Sunt nihil consequuntur fugit suscipit quo pariatur atque nihil temporibus. Aut iure illo est in nihil.', 13, 21, 12, '.\\resources\\images\\poster.png', 0, 'Y5', '2012-03-23', 0, 7, 3, '2024-12-01 21:38:51', '2024-12-01 21:38:51'),
(15, 'sunt', 'Molestias tenetur harum est error repellendus. Occaecati iste assumenda id ratione. Est nostrum recusandae odit laudantium molestiae eum saepe quia est.', 29, 10, 7, '.\\resources\\images\\poster.png', 0, 'L6', '2018-11-24', 0, 7, 5, '2024-12-01 21:38:51', '2024-12-01 21:38:51'),
(16, 'excepturi', 'Officia distinctio dolorem qui praesentium dolor sit voluptate aperiam sit. Et aliquid voluptatem architecto accusamus eveniet voluptas. Hic aspernatur excepturi id dolor veritatis esse tempore ut.', 29, 26, 2, '.\\resources\\images\\poster.png', 0, 'F5', '2015-10-30', 0, 10, 4, '2024-12-01 21:38:51', '2024-12-01 21:38:51'),
(17, 'a', 'Ipsam mollitia voluptatem veritatis quod est reiciendis dolorum non. Et laboriosam et molestias qui. Aut modi autem explicabo odio ipsa quia. Architecto voluptas enim consequatur sed ad ullam adipisci earum. Cumque odit amet necessitatibus voluptatibus.', 21, 30, 11, '.\\resources\\images\\poster.png', 0, 'Y5', '2013-09-08', 0, 8, 1, '2024-12-01 21:38:51', '2024-12-01 21:38:51'),
(18, 'ab', 'Atque exercitationem aut sapiente. Consequatur qui pariatur quia. Saepe sit dolor est blanditiis sed sit. Qui hic ut. Veniam et rerum. Excepturi possimus porro sint cupiditate fuga sit neque.', 26, 23, 16, '.\\resources\\images\\poster.png', 0, 'Y5', '2004-12-22', 0, 7, 1, '2024-12-01 21:38:51', '2024-12-01 21:38:51'),
(19, 'ad', 'Aperiam maxime aut est perspiciatis quia amet. Dolorem omnis voluptatum nam amet molestiae facere consectetur autem ratione. Et porro ea sed maxime nesciunt debitis. Alias magni quam ad minima quam numquam voluptatem animi. Consequatur explicabo porro animi.', 4, 22, 7, '.\\resources\\images\\poster.png', 0, 'L6', '2016-06-10', 0, 7, 3, '2024-12-01 21:38:51', '2024-12-01 21:38:51'),
(20, 'adipisci', 'Qui aut ea. Ut vel sapiente dolorum qui enim assumenda. Explicabo ea repellat velit. Rerum quia et rem.', 26, 14, 5, '.\\resources\\images\\poster.png', 0, 'L6', '2020-08-12', 0, 10, 5, '2024-12-01 21:38:51', '2024-12-01 21:38:51'),
(21, 'ea', 'Enim aut itaque sint animi recusandae at dolor. Reprehenderit sit repellendus rem ut fugit quo laudantium laudantium. Autem ipsa aut nisi totam at. Ipsa eius fuga. Aperiam non veniam beatae vel laboriosam. Consequuntur et laudantium dolorum pariatur quia quisquam debitis quia impedit.', 16, 19, 11, '.\\resources\\images\\poster.png', 0, 'F5', '2019-12-11', 0, 8, 5, '2024-12-01 21:38:51', '2024-12-01 21:38:51'),
(22, 'a', 'Nam dolor ad impedit mollitia qui aut ab iste sed. Est odio non saepe autem nisi in consequatur temporibus qui. Vitae quidem facilis sint id quisquam omnis sit consequatur. Ad veniam ut aut aliquam doloribus tenetur sed.', 12, 14, 27, '.\\resources\\images\\poster.png', 0, 'T5', '2024-10-06', 0, 10, 2, '2024-12-01 21:38:51', '2024-12-01 21:38:51'),
(23, 'sed', 'Veniam debitis minus eos voluptas recusandae dolorum. Et in id ut voluptatem nulla qui et explicabo. Animi et quos in sunt.', 20, 15, 24, '.\\resources\\images\\poster.png', 0, 'L6', '2005-10-31', 0, 8, 3, '2024-12-01 21:38:51', '2024-12-01 21:38:51'),
(24, 'fuga', 'Qui necessitatibus provident qui quod ratione. Ipsum enim sunt possimus. In omnis omnis aliquam est eius sit placeat ea asperiores. Voluptatem quia sed occaecati. Maiores optio nulla.', 20, 29, 2, '.\\resources\\images\\poster.png', 0, 'F5', '2013-07-06', 0, 6, 5, '2024-12-01 21:38:51', '2024-12-01 21:38:51'),
(25, 'harum', 'Aut quia mollitia sequi distinctio atque ab beatae ratione. Eligendi vel animi dolor architecto omnis beatae voluptatum ut at. Totam delectus possimus officiis cum inventore.', 5, 30, 12, '.\\resources\\images\\poster.png', 0, 'T5', '2007-07-26', 0, 6, 0, '2024-12-01 21:38:51', '2024-12-01 21:38:51'),
(26, 'similique', 'Pariatur laboriosam explicabo voluptas sint vel sequi pariatur cum. Quia est et dolorum illum eum ratione maiores. Voluptatem rem qui. Voluptatibus enim numquam voluptatem vero est et est.', 30, 15, 23, '.\\resources\\images\\poster.png', 0, 'L6', '2024-02-26', 0, 10, 0, '2024-12-01 21:38:51', '2024-12-01 21:38:51'),
(27, 'similique', 'Quas quis eos ut sit. Quis error cupiditate sit praesentium qui velit nulla sit. Alias voluptas laborum cum quis maiores accusantium consequatur. Ut eum ex hic quisquam aut. Ad molestiae et hic ex explicabo neque.', 11, 12, 16, '.\\resources\\images\\poster.png', 0, 'Y5', '2002-06-21', 0, 7, 1, '2024-12-01 21:38:51', '2024-12-01 21:38:51'),
(28, 'quae', 'Voluptas voluptas est quod quia mollitia adipisci. Exercitationem voluptates consequuntur debitis. Et sint nobis earum et qui. Eum placeat cum ipsa nostrum non beatae illo.', 28, 19, 25, '.\\resources\\images\\poster.png', 0, 'F5', '2016-09-03', 0, 7, 0, '2024-12-01 21:38:51', '2024-12-01 21:38:51'),
(29, 'aperiam', 'Dolorum eum consequatur. Atque dolore fuga et quasi iusto. Impedit fugit consequatur delectus.', 20, 2, 12, '.\\resources\\images\\poster.png', 0, 'L6', '2001-09-27', 0, 6, 0, '2024-12-01 21:38:51', '2024-12-01 21:38:51'),
(30, 'natus', 'Adipisci culpa est. Nihil labore vitae sit libero quidem quo ut. Voluptatem in sit quia eos recusandae accusamus laudantium. A magni odio ipsa quasi quibusdam saepe.', 18, 20, 15, '.\\resources\\images\\poster.png', 0, 'F5', '2003-10-05', 0, 5, 3, '2024-12-01 21:38:51', '2024-12-01 21:38:51'),
(31, 'voluptatum', 'Temporibus omnis voluptatum et et consequuntur rem explicabo facere dolores. Dolor non ut dignissimos. Saepe commodi earum ab ipsum labore ut quia eligendi cupiditate. Dolorem provident voluptatem amet eius esse qui maxime libero consequatur. Et et perferendis voluptas et nam aperiam tempore. Doloremque ullam magnam qui ullam.', 23, 31, 19, '.\\resources\\images\\poster.png', 0, 'Y5', '2006-01-03', 0, 9, 4, '2024-12-01 21:38:51', '2024-12-01 21:38:51'),
(32, 'eveniet', 'Voluptatem animi accusamus corporis nobis sed. Voluptatem sunt tempora. Ex vel aut. Ratione et et.', 22, 3, 16, '.\\resources\\images\\poster.png', 0, 'T5', '2017-03-04', 0, 7, 3, '2024-12-01 21:38:51', '2024-12-01 21:38:51'),
(33, 'recusandae', 'Sit doloribus dignissimos saepe accusamus minima in. Et eligendi qui quos cupiditate in odit numquam. Vel dignissimos vel non ipsa voluptatem omnis. Quis qui esse. Id facere ab dolorum ut perspiciatis illum esse aliquam. Pariatur illo dolores saepe reiciendis ipsam iure asperiores soluta.', 13, 9, 5, '.\\resources\\images\\poster.png', 0, 'L6', '2006-09-18', 0, 5, 1, '2024-12-01 21:38:51', '2024-12-01 21:38:51'),
(34, 'nesciunt', 'Non libero debitis laboriosam rerum sed deserunt consequuntur. Et animi quis eos non omnis quia. Eum vel aspernatur animi. Aliquid exercitationem alias molestiae iusto rerum ab et autem. Impedit ut et voluptas aut odio. Repellendus quia aut cupiditate animi officiis.', 4, 17, 22, '.\\resources\\images\\poster.png', 0, 'T5', '2019-01-10', 0, 6, 2, '2024-12-01 21:38:51', '2024-12-01 21:38:51'),
(35, 'magni', 'Sequi laudantium aut veniam. Ullam laboriosam sunt aut cumque optio minus harum fuga. Ut similique consequuntur nostrum quod ad consequatur. Doloribus vitae aliquam quae nesciunt voluptatum enim consequuntur omnis. Et harum omnis.', 19, 32, 16, '.\\resources\\images\\poster.png', 0, 'L6', '2008-12-18', 0, 10, 4, '2024-12-01 21:38:51', '2024-12-01 21:38:51'),
(36, 'itaque', 'Quibusdam et eum molestiae qui nemo deserunt voluptas. Et in distinctio reiciendis et velit. Delectus et quas aut voluptatem. Natus dolorem ea. Ut optio sed dolorem laudantium repellendus.', 8, 27, 22, '.\\resources\\images\\poster.png', 0, 'F5', '2010-03-22', 0, 5, 2, '2024-12-01 21:38:51', '2024-12-01 21:38:51'),
(37, 'impedit', 'Eius laudantium tenetur beatae qui facilis numquam minima. Et rerum est et fuga id rerum eius non. Magni quisquam perferendis autem fuga. Porro unde esse sed ut officiis officia sit placeat illo. Itaque provident perspiciatis.', 4, 1, 29, '.\\resources\\images\\poster.png', 0, 'D4', '2007-01-31', 0, 8, 3, '2024-12-01 21:38:51', '2024-12-01 21:38:51'),
(38, 'velit', 'Unde non cum. Asperiores quia exercitationem aut impedit. Labore dolor voluptate natus. Dolore tenetur sit quam et sit enim nam nostrum quas.', 30, 27, 22, '.\\resources\\images\\poster.png', 0, 'T5', '2017-04-09', 0, 8, 3, '2024-12-01 21:38:51', '2024-12-01 21:38:51');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `categories`
--

CREATE TABLE `categories` (
  `Id` int(11) NOT NULL,
  `Name` varchar(40) CHARACTER SET utf8 NOT NULL,
  `Description` varchar(200) CHARACTER SET utf8 NOT NULL,
  `create_at` date NOT NULL,
  `update_at` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `categories`
--

INSERT INTO `categories` (`Id`, `Name`, `Description`, `create_at`, `update_at`) VALUES
(1, 'qui', 'Nulla nulla nemo modi eos ab a ea rem deleniti et et voluptatum vero ut quia non est animi sunt.', '2024-12-01', '2024-12-01'),
(2, 'et', 'Est adipisci officia facilis sed error facere fuga vitae magni est illum rem unde nulla suscipit tempora est quam blanditiis.', '2024-12-01', '2024-12-01'),
(3, 'fugiat', 'Sit qui reiciendis eos excepturi accusamus soluta repellendus nisi molestiae facilis commodi vel non quis voluptatum temporibus mollitia quia ut.', '2024-12-01', '2024-12-01'),
(4, 'est', 'Perferendis maiores et repellat fugit quis dicta perferendis recusandae cum nesciunt incidunt ab repellat est ut quis quia consequatur quam.', '2024-12-01', '2024-12-01'),
(5, 'est', 'Odio quo pariatur eligendi repudiandae velit dolorem perferendis sit ut minus tempora autem minima qui sit voluptatem aut non earum.', '2024-12-01', '2024-12-01');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `categoriesbook`
--

CREATE TABLE `categoriesbook` (
  `CategoryId` int(11) NOT NULL,
  `BookId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `categoriesbook`
--

INSERT INTO `categoriesbook` (`CategoryId`, `BookId`) VALUES
(4, 35),
(5, 31);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `feedbacks`
--

CREATE TABLE `feedbacks` (
  `BookId` int(11) NOT NULL,
  `UserId` int(11) NOT NULL,
  `comment` varchar(200) CHARACTER SET utf8 DEFAULT NULL,
  `rating` float DEFAULT NULL,
  `created_at` datetime NOT NULL,
  `updated_at` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `genres`
--

CREATE TABLE `genres` (
  `id` int(11) NOT NULL,
  `name` varchar(50) CHARACTER SET utf8 NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `genres`
--

INSERT INTO `genres` (`id`, `name`) VALUES
(1, 'dignissimos'),
(2, 'molestiae'),
(3, 'fugiat'),
(4, 'et'),
(5, 'quasi'),
(6, 'ipsa'),
(7, 'nulla'),
(8, 'hic'),
(9, 'eveniet'),
(10, 'magni'),
(11, 'facere'),
(12, 'impedit'),
(13, 'et'),
(14, 'repudiandae'),
(15, 'et'),
(16, 'dolores'),
(17, 'deserunt'),
(18, 'repellendus'),
(19, 'rerum'),
(20, 'consequatur'),
(21, 'aut'),
(22, 'soluta'),
(23, 'sint'),
(24, 'omnis'),
(25, 'laudantium'),
(26, 'dolore'),
(27, 'perferendis'),
(28, 'saepe'),
(29, 'ex'),
(30, 'culpa'),
(31, 'quo'),
(32, 'quia');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `publishers`
--

CREATE TABLE `publishers` (
  `Id` int(11) NOT NULL,
  `Name` varchar(40) CHARACTER SET utf8 NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `publishers`
--

INSERT INTO `publishers` (`Id`, `Name`) VALUES
(1, 'pariatur'),
(2, 'beatae'),
(3, 'impedit'),
(4, 'sapiente'),
(5, 'et'),
(6, 'natus'),
(7, 'porro'),
(8, 'dolores'),
(9, 'minima'),
(10, 'optio'),
(11, 'dolor'),
(12, 'aliquid'),
(13, 'sed'),
(14, 'est'),
(15, 'assumenda'),
(16, 'repellat'),
(17, 'quae'),
(18, 'sed'),
(19, 'itaque'),
(20, 'sed'),
(21, 'quidem'),
(22, 'architecto'),
(23, 'reprehenderit'),
(24, 'aut'),
(25, 'repellendus'),
(26, 'quasi'),
(27, 'laboriosam'),
(28, 'culpa'),
(29, 'voluptas'),
(30, 'qui'),
(31, 'sit'),
(32, 'sed');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `register`
--

CREATE TABLE `register` (
  `Id` int(11) NOT NULL,
  `UserId` int(11) NOT NULL,
  `BookId` int(11) NOT NULL,
  `register_at` datetime NOT NULL,
  `borrow_at` datetime DEFAULT NULL,
  `expected_at` datetime DEFAULT NULL,
  `return_at` datetime DEFAULT NULL,
  `Status` varchar(40) CHARACTER SET utf8 NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `register`
--

INSERT INTO `register` (`Id`, `UserId`, `BookId`, `register_at`, `borrow_at`, `expected_at`, `return_at`, `Status`) VALUES
(1, 6, 37, '2024-11-30 19:43:34', NULL, NULL, NULL, 'Canceled'),
(2, 13, 25, '2024-11-29 04:10:49', '2024-11-27 07:52:09', '2024-12-06 04:10:49', NULL, 'Borrowed'),
(3, 9, 34, '2024-11-27 20:20:47', NULL, NULL, NULL, 'Canceled'),
(4, 7, 13, '2024-11-26 11:13:46', '2024-11-27 05:50:50', '2024-12-03 11:13:46', NULL, 'Borrowed'),
(5, 9, 37, '2024-11-28 15:55:16', NULL, NULL, NULL, 'Canceled'),
(6, 15, 21, '2024-11-30 22:26:06', '2024-11-28 03:56:48', '2024-12-07 22:26:06', '2024-11-30 11:52:27', 'Completed'),
(7, 10, 10, '2024-11-30 22:19:49', NULL, NULL, NULL, 'Pending'),
(8, 7, 19, '2024-11-29 19:44:59', '2024-11-26 19:52:02', '2024-12-06 19:44:59', NULL, 'Borrowed'),
(9, 11, 21, '2024-11-29 13:45:47', '2024-12-01 01:25:37', '2024-12-06 13:45:47', NULL, 'Borrowed'),
(10, 9, 5, '2024-11-27 18:07:13', '2024-11-30 21:08:40', '2024-12-04 18:07:13', '2024-12-01 09:14:47', 'Completed'),
(11, 7, 10, '2024-11-26 21:38:40', '2024-11-29 05:42:53', '2024-12-03 21:38:40', '2024-12-01 16:57:16', 'Completed'),
(12, 9, 8, '2024-11-25 05:05:48', NULL, NULL, NULL, 'Canceled'),
(13, 15, 38, '2024-11-25 16:38:04', NULL, NULL, NULL, 'Pending'),
(14, 3, 3, '2024-11-30 16:46:56', NULL, NULL, NULL, 'Pending'),
(15, 12, 16, '2024-11-26 02:31:24', NULL, NULL, NULL, 'Pending'),
(16, 8, 14, '2024-11-27 02:41:05', NULL, NULL, NULL, 'Canceled'),
(17, 12, 38, '2024-12-01 10:16:05', NULL, NULL, NULL, 'Pending'),
(18, 10, 1, '2024-11-29 00:58:17', '2024-11-26 22:26:14', '2024-12-06 00:58:17', NULL, 'Borrowed'),
(19, 8, 30, '2024-11-27 05:56:55', NULL, NULL, NULL, 'Canceled'),
(20, 16, 6, '2024-11-28 10:56:16', '2024-11-29 07:06:52', '2024-12-05 10:56:16', NULL, 'Borrowed'),
(21, 13, 23, '2024-11-29 06:58:07', NULL, NULL, NULL, 'Pending'),
(22, 9, 30, '2024-12-01 08:02:54', '2024-11-29 22:14:41', '2024-12-08 08:02:54', NULL, 'Borrowed'),
(23, 15, 8, '2024-11-30 11:25:31', '2024-11-27 17:42:36', '2024-12-07 11:25:31', NULL, 'Borrowed'),
(24, 10, 3, '2024-11-26 08:17:38', '2024-11-29 12:15:20', '2024-12-03 08:17:38', '2024-12-01 04:36:05', 'Completed'),
(25, 10, 11, '2024-12-01 10:13:36', NULL, NULL, NULL, 'Canceled'),
(26, 1, 9, '2024-11-28 09:58:50', '2024-11-29 13:54:28', '2024-12-05 09:58:50', '2024-11-29 09:16:55', 'Completed'),
(27, 10, 29, '2024-11-25 17:46:44', '2024-12-01 02:42:18', '2024-12-02 17:46:44', '2024-11-30 10:17:29', 'Completed'),
(28, 3, 13, '2024-11-29 08:02:42', '2024-11-30 12:35:09', '2024-12-06 08:02:42', NULL, 'Borrowed'),
(29, 14, 14, '2024-11-28 08:12:46', NULL, NULL, NULL, 'Pending'),
(30, 12, 35, '2024-11-25 12:17:14', NULL, NULL, NULL, 'Pending'),
(31, 16, 30, '2024-11-27 12:03:04', NULL, NULL, NULL, 'Pending'),
(32, 1, 23, '2024-11-25 15:04:50', NULL, NULL, NULL, 'Pending'),
(33, 1, 28, '2024-12-01 14:38:56', NULL, NULL, NULL, 'Pending'),
(34, 11, 38, '2024-11-26 22:48:42', NULL, NULL, NULL, 'Canceled'),
(35, 5, 35, '2024-11-30 19:29:32', '2024-11-27 03:30:51', '2024-12-07 19:29:32', '2024-12-01 21:38:04', 'Completed'),
(36, 11, 13, '2024-11-26 18:43:11', '2024-12-01 19:54:33', '2024-12-03 18:43:11', NULL, 'Borrowed'),
(37, 16, 20, '2024-11-25 07:22:01', '2024-11-26 10:13:42', '2024-12-02 07:22:01', NULL, 'Borrowed'),
(38, 10, 37, '2024-11-25 08:08:33', NULL, NULL, NULL, 'Canceled'),
(39, 9, 25, '2024-11-27 12:23:00', NULL, NULL, NULL, 'Canceled'),
(40, 10, 16, '2024-11-26 15:22:45', '2024-11-29 23:10:53', '2024-12-03 15:22:45', '2024-11-29 02:54:32', 'Completed');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `storagelocations`
--

CREATE TABLE `storagelocations` (
  `Name` varchar(40) CHARACTER SET utf8 NOT NULL,
  `Description` varchar(200) CHARACTER SET utf8 NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `storagelocations`
--

INSERT INTO `storagelocations` (`Name`, `Description`) VALUES
('D4', 'Suscipit velit qui natus excepturi officiis voluptas nostrum consequatur sed est minus dolorem maiores iusto laboriosam ipsam eius cum repudiandae.'),
('F5', 'Sunt unde tempore omnis est id illum dignissimos accusantium minus laboriosam maiores a possimus maxime molestiae autem adipisci occaecati neque.'),
('L6', 'Delectus quibusdam dolor voluptas repellendus quod in ea est optio voluptas nam a accusamus eaque odio repudiandae delectus maiores veritatis.'),
('T5', 'Minus non exercitationem dolorem magni accusantium dolores iste voluptatibus quis recusandae ea perferendis dolor omnis rerum corporis voluptas dignissimos ullam.'),
('Y5', 'Non commodi aspernatur tempore est adipisci aut hic laboriosam repellat qui saepe et beatae et ratione aspernatur doloremque at fugit.');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `users`
--

CREATE TABLE `users` (
  `Id` int(11) NOT NULL,
  `Name` varchar(40) CHARACTER SET utf8 NOT NULL,
  `Password` varchar(100) NOT NULL,
  `UserName` varchar(100) CHARACTER SET utf8 NOT NULL,
  `Age` int(11) NOT NULL,
  `Gender` varchar(10) NOT NULL,
  `Role` longtext NOT NULL,
  `create_at` date NOT NULL,
  `update_at` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `users`
--

INSERT INTO `users` (`Id`, `Name`, `Password`, `UserName`, `Age`, `Gender`, `Role`, `create_at`, `update_at`) VALUES
(1, 'Maurice Block', 'ut', 'Naomi', 24, 'Female', 'Admin', '2024-12-01', '2024-12-01'),
(2, 'Josue Reinger', 'et', 'Monty', 36, 'Male', 'Admin', '2024-12-01', '2024-12-01'),
(3, 'Noelia Considine', 'pariatur', 'Gracie', 37, 'Male', 'Admin', '2024-12-01', '2024-12-01'),
(4, 'Gussie Hudson', 'qui', 'Yesenia', 30, 'Female', 'User', '2024-12-01', '2024-12-01'),
(5, 'Melody Kihn', 'dolorem', 'Vaughn', 55, 'Male', 'User', '2024-12-01', '2024-12-01'),
(6, 'Magnolia Paucek', 'voluptatem', 'Emely', 53, 'Female', 'Staff', '2024-12-01', '2024-12-01'),
(7, 'June Schimmel', 'ipsam', 'Emma', 48, 'Male', 'Staff', '2024-12-01', '2024-12-01'),
(8, 'Howard Herman', 'natus', 'Gennaro', 59, 'Female', 'Staff', '2024-12-01', '2024-12-01'),
(9, 'Amy Carter', 'est', 'Ruthe', 37, 'Female', 'Staff', '2024-12-01', '2024-12-01'),
(10, 'Alexis Willms', 'iusto', 'Breana', 33, 'Female', 'Staff', '2024-12-01', '2024-12-01'),
(11, 'Valentine Gutkowski', 'ipsum', 'Rory', 46, 'Other', 'Staff', '2024-12-01', '2024-12-01'),
(12, 'Lois Schamberger', 'dolorem', 'Norbert', 24, 'Other', 'Staff', '2024-12-01', '2024-12-01'),
(13, 'Lon Gutmann', 'quo', 'Toby', 52, 'Other', 'Admin', '2024-12-01', '2024-12-01'),
(14, 'Pinkie Huel', 'molestias', 'Winnifred', 43, 'Other', 'Staff', '2024-12-01', '2024-12-01'),
(15, 'Edmund Emmerich', 'dolor', 'Blaise', 49, 'Other', 'Staff', '2024-12-01', '2024-12-01'),
(16, 'Margot Carroll', 'occaecati', 'Hilario', 29, 'Male', 'User', '2024-12-01', '2024-12-01');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Chỉ mục cho các bảng đã đổ
--

--
-- Chỉ mục cho bảng `authors`
--
ALTER TABLE `authors`
  ADD PRIMARY KEY (`Id`);

--
-- Chỉ mục cho bảng `books`
--
ALTER TABLE `books`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `FK_Books_Authors_author_id` (`author_id`),
  ADD KEY `FK_Books_Genres_genre_id` (`genre_id`),
  ADD KEY `FK_Books_Publishers_publisher_id` (`publisher_id`),
  ADD KEY `FK_Books_StorageLocations_storage_location` (`storage_location`);

--
-- Chỉ mục cho bảng `categories`
--
ALTER TABLE `categories`
  ADD PRIMARY KEY (`Id`);

--
-- Chỉ mục cho bảng `categoriesbook`
--
ALTER TABLE `categoriesbook`
  ADD PRIMARY KEY (`BookId`,`CategoryId`),
  ADD KEY `FK_CategoriesBook_Categories_CategoryId` (`CategoryId`);

--
-- Chỉ mục cho bảng `feedbacks`
--
ALTER TABLE `feedbacks`
  ADD PRIMARY KEY (`BookId`,`UserId`),
  ADD KEY `FK_Feedbacks_Users_UserId` (`UserId`);

--
-- Chỉ mục cho bảng `genres`
--
ALTER TABLE `genres`
  ADD PRIMARY KEY (`id`);

--
-- Chỉ mục cho bảng `publishers`
--
ALTER TABLE `publishers`
  ADD PRIMARY KEY (`Id`);

--
-- Chỉ mục cho bảng `register`
--
ALTER TABLE `register`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `FK_Register_Books_BookId` (`BookId`),
  ADD KEY `FK_Register_Users_UserId` (`UserId`);

--
-- Chỉ mục cho bảng `storagelocations`
--
ALTER TABLE `storagelocations`
  ADD PRIMARY KEY (`Name`);

--
-- Chỉ mục cho bảng `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`Id`);

--
-- Chỉ mục cho bảng `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT cho các bảng đã đổ
--

--
-- AUTO_INCREMENT cho bảng `authors`
--
ALTER TABLE `authors`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=33;

--
-- AUTO_INCREMENT cho bảng `books`
--
ALTER TABLE `books`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=39;

--
-- AUTO_INCREMENT cho bảng `categories`
--
ALTER TABLE `categories`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT cho bảng `genres`
--
ALTER TABLE `genres`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=33;

--
-- AUTO_INCREMENT cho bảng `publishers`
--
ALTER TABLE `publishers`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=33;

--
-- AUTO_INCREMENT cho bảng `register`
--
ALTER TABLE `register`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=41;

--
-- AUTO_INCREMENT cho bảng `users`
--
ALTER TABLE `users`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- Các ràng buộc cho các bảng đã đổ
--

--
-- Các ràng buộc cho bảng `books`
--
ALTER TABLE `books`
  ADD CONSTRAINT `FK_Books_Authors_author_id` FOREIGN KEY (`author_id`) REFERENCES `authors` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_Books_Genres_genre_id` FOREIGN KEY (`genre_id`) REFERENCES `genres` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_Books_Publishers_publisher_id` FOREIGN KEY (`publisher_id`) REFERENCES `publishers` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_Books_StorageLocations_storage_location` FOREIGN KEY (`storage_location`) REFERENCES `storagelocations` (`Name`) ON DELETE CASCADE;

--
-- Các ràng buộc cho bảng `categoriesbook`
--
ALTER TABLE `categoriesbook`
  ADD CONSTRAINT `FK_CategoriesBook_Books_BookId` FOREIGN KEY (`BookId`) REFERENCES `books` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_CategoriesBook_Categories_CategoryId` FOREIGN KEY (`CategoryId`) REFERENCES `categories` (`Id`) ON DELETE CASCADE;

--
-- Các ràng buộc cho bảng `feedbacks`
--
ALTER TABLE `feedbacks`
  ADD CONSTRAINT `FK_Feedbacks_Books_BookId` FOREIGN KEY (`BookId`) REFERENCES `books` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_Feedbacks_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `users` (`Id`) ON DELETE CASCADE;

--
-- Các ràng buộc cho bảng `register`
--
ALTER TABLE `register`
  ADD CONSTRAINT `FK_Register_Books_BookId` FOREIGN KEY (`BookId`) REFERENCES `books` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_Register_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `users` (`Id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
