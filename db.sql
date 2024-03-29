USE [Cinema]
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 3/17/2024 6:13:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[bookingId] [int] IDENTITY(1,1) NOT NULL,
	[showId] [int] NOT NULL,
	[userId] [int] NOT NULL,
 CONSTRAINT [PK_booking] PRIMARY KEY CLUSTERED 
(
	[bookingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookingDetails]    Script Date: 3/17/2024 6:13:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookingDetails](
	[bookingId] [int] NOT NULL,
	[seatId] [int] NOT NULL,
 CONSTRAINT [PK_booking_detail] PRIMARY KEY CLUSTERED 
(
	[bookingId] ASC,
	[seatId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 3/17/2024 6:13:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[CountryCode] [nchar](3) NOT NULL,
	[CountryName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[CountryCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Films]    Script Date: 3/17/2024 6:13:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Films](
	[FilmID] [int] IDENTITY(1,1) NOT NULL,
	[GenreID] [int] NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[CountryCode] [nchar](3) NOT NULL,
	[img] [ntext] NULL,
	[premiere] [date] NULL,
	[actor] [nvarchar](300) NULL,
	[author] [nvarchar](100) NULL,
	[time] [int] NULL,
	[images_slide] [ntext] NULL,
	[description] [nvarchar](3000) NULL,
	[status] [bit] NULL,
 CONSTRAINT [PK_Films] PRIMARY KEY CLUSTERED 
(
	[FilmID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genres]    Script Date: 3/17/2024 6:13:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genres](
	[GenreID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Genres] PRIMARY KEY CLUSTERED 
(
	[GenreID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 3/17/2024 6:13:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rooms](
	[RoomID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
 CONSTRAINT [PK_Rooms] PRIMARY KEY CLUSTERED 
(
	[RoomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Seat]    Script Date: 3/17/2024 6:13:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seat](
	[seatId] [int] IDENTITY(1,1) NOT NULL,
	[seatName] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Seat] PRIMARY KEY CLUSTERED 
(
	[seatId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Show]    Script Date: 3/17/2024 6:13:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Show](
	[showId] [int] IDENTITY(1,1) NOT NULL,
	[showDate] [date] NOT NULL,
	[slotId] [int] NOT NULL,
	[filmId] [int] NOT NULL,
	[roomId] [int] NOT NULL,
	[status] [int] NULL,
 CONSTRAINT [PK_Show] PRIMARY KEY CLUSTERED 
(
	[showId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Slot]    Script Date: 3/17/2024 6:13:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slot](
	[slotId] [int] NOT NULL,
	[Time] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Slot] PRIMARY KEY CLUSTERED 
(
	[slotId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user]    Script Date: 3/17/2024 6:13:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[fullname] [nvarchar](50) NULL,
	[email] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[gender] [bit] NULL,
	[phone] [nchar](11) NULL,
	[address] [nvarchar](100) NULL,
	[role] [int] NULL,
	[DOB] [date] NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Booking] ON 

INSERT [dbo].[Booking] ([bookingId], [showId], [userId]) VALUES (1, 1, 3)
INSERT [dbo].[Booking] ([bookingId], [showId], [userId]) VALUES (2, 1, 1)
INSERT [dbo].[Booking] ([bookingId], [showId], [userId]) VALUES (3, 1, 1)
INSERT [dbo].[Booking] ([bookingId], [showId], [userId]) VALUES (4, 12, 1)
INSERT [dbo].[Booking] ([bookingId], [showId], [userId]) VALUES (5, 12, 3)
INSERT [dbo].[Booking] ([bookingId], [showId], [userId]) VALUES (6, 12, 3)
INSERT [dbo].[Booking] ([bookingId], [showId], [userId]) VALUES (7, 1, 3)
INSERT [dbo].[Booking] ([bookingId], [showId], [userId]) VALUES (8, 1, 5)
INSERT [dbo].[Booking] ([bookingId], [showId], [userId]) VALUES (9, 1, 5)
INSERT [dbo].[Booking] ([bookingId], [showId], [userId]) VALUES (10, 2, 5)
INSERT [dbo].[Booking] ([bookingId], [showId], [userId]) VALUES (11, 18, 6)
INSERT [dbo].[Booking] ([bookingId], [showId], [userId]) VALUES (12, 19, 5)
INSERT [dbo].[Booking] ([bookingId], [showId], [userId]) VALUES (16, 2, 6)
SET IDENTITY_INSERT [dbo].[Booking] OFF
GO
INSERT [dbo].[BookingDetails] ([bookingId], [seatId]) VALUES (1, 12)
INSERT [dbo].[BookingDetails] ([bookingId], [seatId]) VALUES (1, 13)
INSERT [dbo].[BookingDetails] ([bookingId], [seatId]) VALUES (2, 15)
INSERT [dbo].[BookingDetails] ([bookingId], [seatId]) VALUES (2, 16)
INSERT [dbo].[BookingDetails] ([bookingId], [seatId]) VALUES (2, 18)
INSERT [dbo].[BookingDetails] ([bookingId], [seatId]) VALUES (3, 1)
INSERT [dbo].[BookingDetails] ([bookingId], [seatId]) VALUES (3, 2)
INSERT [dbo].[BookingDetails] ([bookingId], [seatId]) VALUES (4, 1)
INSERT [dbo].[BookingDetails] ([bookingId], [seatId]) VALUES (4, 2)
INSERT [dbo].[BookingDetails] ([bookingId], [seatId]) VALUES (4, 15)
INSERT [dbo].[BookingDetails] ([bookingId], [seatId]) VALUES (4, 16)
INSERT [dbo].[BookingDetails] ([bookingId], [seatId]) VALUES (5, 28)
INSERT [dbo].[BookingDetails] ([bookingId], [seatId]) VALUES (5, 29)
INSERT [dbo].[BookingDetails] ([bookingId], [seatId]) VALUES (6, 20)
INSERT [dbo].[BookingDetails] ([bookingId], [seatId]) VALUES (6, 21)
INSERT [dbo].[BookingDetails] ([bookingId], [seatId]) VALUES (7, 20)
INSERT [dbo].[BookingDetails] ([bookingId], [seatId]) VALUES (7, 21)
INSERT [dbo].[BookingDetails] ([bookingId], [seatId]) VALUES (7, 28)
INSERT [dbo].[BookingDetails] ([bookingId], [seatId]) VALUES (7, 29)
INSERT [dbo].[BookingDetails] ([bookingId], [seatId]) VALUES (8, 3)
INSERT [dbo].[BookingDetails] ([bookingId], [seatId]) VALUES (8, 4)
INSERT [dbo].[BookingDetails] ([bookingId], [seatId]) VALUES (9, 22)
INSERT [dbo].[BookingDetails] ([bookingId], [seatId]) VALUES (9, 23)
INSERT [dbo].[BookingDetails] ([bookingId], [seatId]) VALUES (9, 24)
INSERT [dbo].[BookingDetails] ([bookingId], [seatId]) VALUES (10, 4)
INSERT [dbo].[BookingDetails] ([bookingId], [seatId]) VALUES (10, 5)
INSERT [dbo].[BookingDetails] ([bookingId], [seatId]) VALUES (11, 1)
INSERT [dbo].[BookingDetails] ([bookingId], [seatId]) VALUES (11, 2)
INSERT [dbo].[BookingDetails] ([bookingId], [seatId]) VALUES (11, 3)
INSERT [dbo].[BookingDetails] ([bookingId], [seatId]) VALUES (12, 11)
INSERT [dbo].[BookingDetails] ([bookingId], [seatId]) VALUES (12, 12)
INSERT [dbo].[BookingDetails] ([bookingId], [seatId]) VALUES (16, 18)
INSERT [dbo].[BookingDetails] ([bookingId], [seatId]) VALUES (16, 22)
GO
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'ABW', N'Aruba')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'AFG', N'Afghanistan')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'AGO', N'Angola')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'AIA', N'Anguilla')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'ALB', N'Albania')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'AND', N'Andorra')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'ANT', N'Netherlands Antilles')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'ARE', N'United Arab Emirates')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'ARG', N'Argentina')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'ARM', N'Armenia')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'ASM', N'American Samoa')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'ATA', N'Antarctica')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'ATG', N'Antigua and Barbuda')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'AUS', N'Australia')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'AUT', N'Austria')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'AZE', N'Azerbaijan')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'BDI', N'Burundi')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'BEL', N'Belgium')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'BEN', N'Benin')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'BFA', N'Burkina Faso')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'BGD', N'Bangladesh')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'BGR', N'Bulgaria')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'BHR', N'Bahrain')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'BHS', N'Bahamas')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'BIH', N'Bosnia and Herzegovina')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'BLM', N'Saint Barthelemy')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'BLR', N'Belarus')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'BLZ', N'Belize')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'BMU', N'Bermuda')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'BOL', N'Bolivia')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'BRA', N'Brazil')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'BRB', N'Barbados')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'BRN', N'Brunei')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'BTN', N'Bhutan')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'BWA', N'Botswana')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'CAF', N'Central African Republic')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'CAN', N'Canada')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'CCK', N'Cocos (Keeling) Islands')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'CHE', N'Switzerland')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'CHL', N'Chile')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'CHN', N'China')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'CIV', N'Ivory Coast')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'CMR', N'Cameroon')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'COD', N'Democratic Republic of the Congo')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'COG', N'Republic of the Congo')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'COK', N'Cook Islands')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'COL', N'Colombia')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'COM', N'Comoros')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'CPV', N'Cape Verde')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'CRC', N'Costa Rica')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'CUB', N'Cuba')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'CXR', N'Christmas Island')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'CYM', N'Cayman Islands')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'CYP', N'Cyprus')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'CZE', N'Czech Republic')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'DEU', N'Germany')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'DJI', N'Djibouti')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'DMA', N'Dominica')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'DNK', N'Denmark')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'DOM', N'Dominican Republic')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'DZA', N'Algeria')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'ECU', N'Ecuador')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'EGY', N'Egypt')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'ERI', N'Eritrea')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'ESH', N'Western Sahara')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'ESP', N'Spain')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'EST', N'Estonia')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'ETH', N'Ethiopia')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'FIN', N'Finland')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'FJI', N'Fiji')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'FLK', N'Falkland Islands')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'FRA', N'France')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'FRO', N'Faroe Islands')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'FSM', N'Micronesia')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'GAB', N'Gabon')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'GBR', N'United Kingdom')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'GEO', N'Georgia')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'GHA', N'Ghana')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'GIB', N'Gibraltar')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'GIN', N'Guinea')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'GMB', N'Gambia')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'GNB', N'Guinea-Bissau')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'GNQ', N'Equatorial Guinea')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'GRC', N'Greece')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'GRD', N'Grenada')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'GRL', N'Greenland')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'GTM', N'Guatemala')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'GUM', N'Guam')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'GUY', N'Guyana')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'HKG', N'Hong Kong')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'HND', N'Honduras')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'HRV', N'Croatia')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'HTI', N'Haiti')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'HUN', N'Hungary')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'IDN', N'Indonesia')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'IMN', N'Isle of Man')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'IND', N'India')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'IOT', N'British Indian Ocean Territory')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'IRL', N'Ireland')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'IRN', N'Iran')
GO
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'IRQ', N'Iraq')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'ISR', N'Israel')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'ITA', N'Italy')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'JAM', N'Jamaica')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'JEY', N'Jersey')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'JOR', N'Jordan')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'JPN', N'Japan')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'KAZ', N'Kazakhstan')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'KEN', N'Kenya')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'KGZ', N'Kyrgyzstan')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'KHM', N'Cambodia')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'KIR', N'Kiribati')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'KNA', N'Saint Kitts and Nevis')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'KOR', N'South Korea')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'KWT', N'Kuwait')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'LAO', N'Laos')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'LBN', N'Lebanon')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'LBR', N'Liberia')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'LBY', N'Libya')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'LCA', N'Saint Lucia')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'LIE', N'Liechtenstein')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'LKA', N'Sri Lanka')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'LSO', N'Lesotho')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'LTU', N'Lithuania')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'LUX', N'Luxembourg')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'LVA', N'Latvia')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'MAC', N'Macau')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'MAF', N'Saint Martin')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'MAR', N'Morocco')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'MCO', N'Monaco')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'MDA', N'Moldova')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'MDG', N'Madagascar')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'MDV', N'Maldives')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'MEX', N'Mexico')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'MHL', N'Marshall Islands')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'MKD', N'Macedonia')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'MLI', N'Mali')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'MLT', N'Malta')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'MMR', N'Burma (Myanmar)')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'MNE', N'Montenegro')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'MNG', N'Mongolia')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'MNP', N'Northern Mariana Islands')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'MOZ', N'Mozambique')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'MRT', N'Mauritania')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'MSR', N'Montserrat')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'MUS', N'Mauritius')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'MWI', N'Malawi')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'MYS', N'Malaysia')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'MYT', N'Mayotte')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'NAM', N'Namibia')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'NCL', N'New Caledonia')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'NER', N'Niger')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'NFK', N'Norfolk Island')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'NGA', N'Nigeria')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'NIC', N'Nicaragua')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'NIU', N'Niue')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'NLD', N'Netherlands')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'NOR', N'Norway')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'NPL', N'Nepal')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'NRU', N'Nauru')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'NZL', N'New Zealand')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'OMN', N'Oman')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'PAK', N'Pakistan')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'PAN', N'Panama')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'PCN', N'Pitcairn Islands')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'PER', N'Peru')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'PHL', N'Philippines')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'PLW', N'Palau')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'PNG', N'Papua New Guinea')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'POL', N'Poland')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'PRI', N'Puerto Rico')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'PRK', N'North Korea')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'PRT', N'Portugal')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'PRY', N'Paraguay')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'PYF', N'French Polynesia')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'QAT', N'Qatar')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'ROU', N'Romania')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'RUS', N'Russia')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'RWA', N'Rwanda')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'SAU', N'Saudi Arabia')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'SDN', N'Sudan')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'SEN', N'Senegal')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'SGP', N'Singapore')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'SHN', N'Saint Helena')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'SJM', N'Svalbard')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'SLB', N'Solomon Islands')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'SLE', N'Sierra Leone')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'SLV', N'El Salvador')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'SMR', N'San Marino')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'SOM', N'Somalia')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'SPM', N'Saint Pierre and Miquelon')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'SRB', N'Serbia')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'STP', N'Sao Tome and Principe')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'SUR', N'Suriname')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'SVK', N'Slovakia')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'SVN', N'Slovenia')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'SWE', N'Sweden')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'SWZ', N'Swaziland')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'SYC', N'Seychelles')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'SYR', N'Syria')
GO
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'TCA', N'Turks and Caicos Islands')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'TCD', N'Chad')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'TGO', N'Togo')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'THA', N'Thailand')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'TJK', N'Tajikistan')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'TKL', N'Tokelau')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'TKM', N'Turkmenistan')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'TLS', N'Timor-Leste')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'TON', N'Tonga')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'TTO', N'Trinidad and Tobago')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'TUN', N'Tunisia')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'TUR', N'Turkey')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'TUV', N'Tuvalu')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'TWN', N'Taiwan')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'TZA', N'Tanzania')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'UGA', N'Uganda')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'UKR', N'Ukraine')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'URY', N'Uruguay')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'USA', N'United States')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'UZB', N'Uzbekistan')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'VAT', N'Holy See (Vatican City)')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'VCT', N'Saint Vincent and the Grenadines')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'VEN', N'Venezuela')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'VGB', N'British Virgin Islands')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'VIR', N'US Virgin Islands')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'VNM', N'Vietnam')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'VUT', N'Vanuatu')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'WLF', N'Wallis and Futuna')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'WSM', N'Samoa')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'YEM', N'Yemen')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'ZAF', N'South Africa')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'ZMB', N'Zambia')
INSERT [dbo].[Countries] ([CountryCode], [CountryName]) VALUES (N'ZWE', N'Zimbabwe')
GO
SET IDENTITY_INSERT [dbo].[Films] ON 

INSERT [dbo].[Films] ([FilmID], [GenreID], [Title], [CountryCode], [img], [premiere], [actor], [author], [time], [images_slide], [description], [status]) VALUES (1, 4, N' Minions the rise of gru', N'USA', N'https://m.media-amazon.com/images/M/MV5BNjZlZjU0NTUtNDlmNC00MjkxLWI3YzItZGJmMmU2OWZhY2JhXkEyXkFqcGdeQXZ3ZXNsZXk@._V1_.jpg', CAST(N'2020-11-01' AS Date), N'Julie Andrews, Alan Arkin, Lucy Lawless, Dolph Lundgren', N'Steve Carell', 112, N'download.jpg', N'Character returns in this uproarious animated comedy. Join Gru and his mischievous minions on a hilarious journey as they embark on a quest for 
villainous greatness. Filled with laughs and lovable characters, The Rise of Gru delivers riotous fun for audiences of all ages.', 1)
INSERT [dbo].[Films] ([FilmID], [GenreID], [Title], [CountryCode], [img], [premiere], [actor], [author], [time], [images_slide], [description], [status]) VALUES (2, 8, N'Thor: Love an Thunder', N'TCD', N'https://kubrick.htvapps.com/htv-prod-media.s3.amazonaws.com/images/thanksgiving-pic-6557c2263e664.jpg?crop=0.934xw:1.00xh;0.0337xw,0&resize=900:*', CAST(N'2024-03-16' AS Date), N'Julie A', N'Steve Carell', 120, N'Thor_Love_An', N'Steve Carell explores culture and society in this highly anticipated sequel to the Marvel Cinematic Universe. As Thor faces new challenges and embraces his identity, he 
embarks on a cosmic adventure filled with humor, heart, and thunderous action. With dazzling visuals and dynamic characters, Love and Thunder electrifies audiences with 
its epic scope and emotional depth', 1)
INSERT [dbo].[Films] ([FilmID], [GenreID], [Title], [CountryCode], [img], [premiere], [actor], [author], [time], [images_slide], [description], [status]) VALUES (3, 9, N'Paws of Fury: The Legend of Hank', N'USA', N'https://thumbnails.cbsig.net/CBS_Production_Entertainment_VMS/2022/08/02/2057958979742/POF_SAlone_16_9_1920x1080_1584766_1920x1080.jpg', CAST(N'2021-06-06' AS Date), N'Julie Andrews, Alan Arkin, Lucy Lawless, Dolph Lundgren', N'Steve Carell', 120, N'maxresdefault.jpg', N'Steve Carell takes on a dramatic role in this heartwarming tale of resilience and redemption. Follow Hank, a courageous dog, as he overcomes adversity and discovers the 
true meaning of family. With touching moments and uplifting themes, Paws of Fury celebrates the indomitable spirit of man''s best friend', 1)
INSERT [dbo].[Films] ([FilmID], [GenreID], [Title], [CountryCode], [img], [premiere], [actor], [author], [time], [images_slide], [description], [status]) VALUES (4, 1, N'God father II                                                                                       ', N'UGA', N'https://mannup.vn/wp-content/uploads/2015/01/the-godfather-part-ii-012.jpg', CAST(N'2022-08-09' AS Date), N'Julie Andrews, Alan Arkin, Lucy Lawless, Dolph Lundgren', N'Steve Carell', 120, N'download (1).jpg', N' Steve Carell stars in this action-packed sequel to the iconic crime saga. Set against the backdrop of organized crime, the film delves deeper into the Corleone family''s 
complex dynamics and power struggles. With masterful direction and powerhouse performances, Godfather II remains a timeless classic, captivating audiences with its 
gripping storytelling and moral ambiguity', 1)
INSERT [dbo].[Films] ([FilmID], [GenreID], [Title], [CountryCode], [img], [premiere], [actor], [author], [time], [images_slide], [description], [status]) VALUES (7, 3, N'The Scraw', N'USA', N'https://kubrick.htvapps.com/htv-prod-media.s3.amazonaws.com/images/the-marvels-pic-654ea15306aeb.jpg?crop=1.00xw:0.966xh;0,0.0335xh&resize=900:*', CAST(N'2022-11-11' AS Date), N'Julie Andrews, Alan Arkin, Lucy Lawless, Dolph Lundgren', N'Steve Carell', 120, NULL, N' Steve Carell delves into the world of business in this gripping drama. Follow the intense journey of a determined entrepreneur as he navigates through challenges and 
triumphs, risking everything for success. With compelling performances and a riveting narrative, The Scraw explores the relentless pursuit of ambition and the price of 
achievemen', 1)
INSERT [dbo].[Films] ([FilmID], [GenreID], [Title], [CountryCode], [img], [premiere], [actor], [author], [time], [images_slide], [description], [status]) VALUES (9, 4, N'Dragon ball', N'USA', N'https://kubrick.htvapps.com/htv-prod-media.s3.amazonaws.com/images/wonka-pic-657cc89615b22.jpg?crop=1.00xw:0.944xh;0,0.0563xh&resize=900:*', CAST(N'2022-01-23' AS Date), N'Julie Andrews, Alan Arkin, Lucy Lawless, Dolph Lundgren', N'Steve Carell', 120, NULL, N' Steve Carell brings the beloved characters of Dragon Ball to life in this thrilling children''s/family film. Join Goku and his friends as they embark on a quest to protect Earth 
from powerful adversaries. Filled with epic battles and heartwarming moments, Dragon Ball captivates audiences of all ages with its vibrant energy and spirit.', 1)
INSERT [dbo].[Films] ([FilmID], [GenreID], [Title], [CountryCode], [img], [premiere], [actor], [author], [time], [images_slide], [description], [status]) VALUES (10, 1, N'Avatar', N'USA', N'https://kubrick.htvapps.com/htv-prod-media.s3.amazonaws.com/images/the-beekeeper-pic-65a1ae2134fc0.jpg?crop=1.00xw:0.961xh;0,0.0194xh&resize=900:*', CAST(N'2022-08-15' AS Date), N'Julie Andrews, Alan Arkin, Lucy Lawless, Dolph Lundgren', N'Steve Carell', 120, NULL, N' Steve Carell stars in this action-packed epic set on the mesmerizing world of Pandora. Immerse yourself in a visually stunning adventure as humans clash with indigenous 
Na''vi, challenging perceptions of power and nature. With groundbreaking visuals and gripping storytelling, Avatar transports audiences to a realm of breathtaking beauty 
and conflict.', 1)
INSERT [dbo].[Films] ([FilmID], [GenreID], [Title], [CountryCode], [img], [premiere], [actor], [author], [time], [images_slide], [description], [status]) VALUES (11, 2, N'Pororo and friend', N'USA', N'https://kubrick.htvapps.com/htv-prod-media.s3.amazonaws.com/images/out-of-darkness-pic-65c69fbd5a335.jpg?crop=1.00xw:0.846xh;0,0.154xh&resize=900:*', CAST(N'2022-12-12' AS Date), N'Julie Andrews, Alan Arkin, Lucy Lawless, Dolph Lundgren', N'Steve Carell', 120, NULL, N'Join Steve Carell on an adventurous journey with Pororo and friends in this charming animated tale. As they embark on a quest filled with wonder and excitement, they 
learn valuable lessons about friendship and perseverance. With captivating animation and lovable characters, it''s an enchanting adventure for the whole family.', 1)
INSERT [dbo].[Films] ([FilmID], [GenreID], [Title], [CountryCode], [img], [premiere], [actor], [author], [time], [images_slide], [description], [status]) VALUES (12, 13, N'Top Gun Maverick', N'ESP', N'https://kubrick.htvapps.com/htv-prod-media.s3.amazonaws.com/images/dune-part-two-pic-65e247c2b3680.jpg?crop=0.992xw:1.00xh;0.00489xw,0&resize=900:*', CAST(N'2022-09-12' AS Date), N'Julie Andrews, Alan Arkin, Lucy Lawless, Dolph Lundgren', N'Steve Carell', 120, NULL, N'Set against a historical backdrop, Steve Carell takes flight in this adrenaline-fueled sequel. Maverick returns to the skies, navigating through danger and nostalgia. With 
breathtaking aerial maneuvers and heartfelt tributes, Maverick''s journey honors the legacy of courage and camaraderie, soaring to new heights of cinematic excellence.', 1)
INSERT [dbo].[Films] ([FilmID], [GenreID], [Title], [CountryCode], [img], [premiere], [actor], [author], [time], [images_slide], [description], [status]) VALUES (13, 1, N'Black Adam', N'ESP', N'https://kubrick.htvapps.com/htv-prod-media.s3.amazonaws.com/images/black-adam-pic-1666378839.jpg?crop=0.934xw:1.00xh;0.0337xw,0&resize=900:*', CAST(N'2022-08-23' AS Date), N'Julie Andrews, Alan Arkin, Lucy Lawless, Dolph Lundgren', N'Steve Carell', 120, N'https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.kcci.com%2Farticle%2Fmovie-review-black-adam%2F41738381&psig=AOvVaw2d65w-gQA1dR3QitrVHcoA&ust=1710713440289000&source=images&cd=vfe&opi=89978449&ved=0CBUQjhxqFwoTCIjErqnm-YQDFQAAAAAdAAAAABAE', N'A thrilling action flick starring Steve Carell, where ancient powers clash as the titular anti-hero emerges. Fueled by vengeance and immense strength, Black Adam battles 
against evil forces, shaping his destiny and the fate of the world. An electrifying adventure packed with intense action sequences and gripping storytelling.', 1)
INSERT [dbo].[Films] ([FilmID], [GenreID], [Title], [CountryCode], [img], [premiere], [actor], [author], [time], [images_slide], [description], [status]) VALUES (15, 4, N'Connan', N'ESP', N'https://vov2.vov.vn/sites/default/files/styles/large/public/2022-07/image007.jpg', CAST(N'2022-09-10' AS Date), N'Julie Andrews, Alan Arkin, Lucy Lawless, Dolph Lundgren', N'Steve Carell', 120, NULL, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod temp incididunt ut labore et dolore magna aliqua. Quis ipsum suspendisse. Donec condimentum 
elementum convallis. Nunc sed orci a diam ultrices aliquet interdum quis nulla.', 1)
INSERT [dbo].[Films] ([FilmID], [GenreID], [Title], [CountryCode], [img], [premiere], [actor], [author], [time], [images_slide], [description], [status]) VALUES (17, 9, N'Mogadishu', N'ESP', N'https://i.ytimg.com/vi/uDyM8zmhQtc/maxresdefault.jpg', CAST(N'2022-09-30' AS Date), N'Julie Andrews, Alan Arkin, Lucy Lawless, Dolph Lundgren', N'Steve Carell', 120, NULL, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod temp incididunt ut labore et dolore magna aliqua. Quis ipsum suspendisse. Donec condimentum 
elementum convallis. Nunc sed orci a diam ultrices aliquet interdum quis nulla.', 1)
INSERT [dbo].[Films] ([FilmID], [GenreID], [Title], [CountryCode], [img], [premiere], [actor], [author], [time], [images_slide], [description], [status]) VALUES (23, 4, N'Bullet train', N'USA', N'https://m.media-amazon.com/images/M/MV5BZWUxZjA0YWQtYTc2Yy00YTRhLWFlNzUtYmEwMTY2ZTQxNmVmXkEyXkFqcGdeQXJoYW5uYWg@._V1_.jpg', CAST(N'2022-10-11' AS Date), N'Julie Andrews, Alan Arkin, Lucy Lawless, Dolph Lundgren', N'Steve Carell', 120, NULL, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod temp incididunt ut labore et dolore magna aliqua. Quis ipsum suspendisse. Donec condimentum 
elementum convallis. Nunc sed orci a diam ultrices aliquet interdum quis nulla.', 1)
SET IDENTITY_INSERT [dbo].[Films] OFF
GO
SET IDENTITY_INSERT [dbo].[Genres] ON 

INSERT [dbo].[Genres] ([GenreID], [Name]) VALUES (1, N'Action')
INSERT [dbo].[Genres] ([GenreID], [Name]) VALUES (2, N'Adventure')
INSERT [dbo].[Genres] ([GenreID], [Name]) VALUES (3, N'Business ')
INSERT [dbo].[Genres] ([GenreID], [Name]) VALUES (4, N'Children''s/Family  ')
INSERT [dbo].[Genres] ([GenreID], [Name]) VALUES (5, N'Comedy ')
INSERT [dbo].[Genres] ([GenreID], [Name]) VALUES (6, N'Comedy Drama ')
INSERT [dbo].[Genres] ([GenreID], [Name]) VALUES (7, N'Crime    ')
INSERT [dbo].[Genres] ([GenreID], [Name]) VALUES (8, N'Culture & Socienty    ')
INSERT [dbo].[Genres] ([GenreID], [Name]) VALUES (9, N'Drama   ')
INSERT [dbo].[Genres] ([GenreID], [Name]) VALUES (10, N'Education   ')
INSERT [dbo].[Genres] ([GenreID], [Name]) VALUES (13, N'Historical Film ')
SET IDENTITY_INSERT [dbo].[Genres] OFF
GO
SET IDENTITY_INSERT [dbo].[Rooms] ON 

INSERT [dbo].[Rooms] ([RoomID], [Name]) VALUES (1, N'Theatre A                                                                                           ')
INSERT [dbo].[Rooms] ([RoomID], [Name]) VALUES (2, N'Theatre B                                                                                           ')
INSERT [dbo].[Rooms] ([RoomID], [Name]) VALUES (3, N'Theatre C                                                                                           ')
SET IDENTITY_INSERT [dbo].[Rooms] OFF
GO
SET IDENTITY_INSERT [dbo].[Seat] ON 

INSERT [dbo].[Seat] ([seatId], [seatName]) VALUES (1, N'A1        ')
INSERT [dbo].[Seat] ([seatId], [seatName]) VALUES (2, N'A2        ')
INSERT [dbo].[Seat] ([seatId], [seatName]) VALUES (3, N'A3        ')
INSERT [dbo].[Seat] ([seatId], [seatName]) VALUES (4, N'A4        ')
INSERT [dbo].[Seat] ([seatId], [seatName]) VALUES (5, N'A5        ')
INSERT [dbo].[Seat] ([seatId], [seatName]) VALUES (6, N'A6        ')
INSERT [dbo].[Seat] ([seatId], [seatName]) VALUES (7, N'A7        ')
INSERT [dbo].[Seat] ([seatId], [seatName]) VALUES (8, N'A8        ')
INSERT [dbo].[Seat] ([seatId], [seatName]) VALUES (9, N'B1')
INSERT [dbo].[Seat] ([seatId], [seatName]) VALUES (10, N'B2')
INSERT [dbo].[Seat] ([seatId], [seatName]) VALUES (11, N'B3')
INSERT [dbo].[Seat] ([seatId], [seatName]) VALUES (12, N'B4')
INSERT [dbo].[Seat] ([seatId], [seatName]) VALUES (13, N'B5')
INSERT [dbo].[Seat] ([seatId], [seatName]) VALUES (14, N'B6')
INSERT [dbo].[Seat] ([seatId], [seatName]) VALUES (15, N'B7')
INSERT [dbo].[Seat] ([seatId], [seatName]) VALUES (16, N'B8')
INSERT [dbo].[Seat] ([seatId], [seatName]) VALUES (17, N'C1')
INSERT [dbo].[Seat] ([seatId], [seatName]) VALUES (18, N'C2')
INSERT [dbo].[Seat] ([seatId], [seatName]) VALUES (19, N'C3')
INSERT [dbo].[Seat] ([seatId], [seatName]) VALUES (20, N'C4')
INSERT [dbo].[Seat] ([seatId], [seatName]) VALUES (21, N'C5')
INSERT [dbo].[Seat] ([seatId], [seatName]) VALUES (22, N'C6')
INSERT [dbo].[Seat] ([seatId], [seatName]) VALUES (23, N'C7')
INSERT [dbo].[Seat] ([seatId], [seatName]) VALUES (24, N'C8')
INSERT [dbo].[Seat] ([seatId], [seatName]) VALUES (25, N'D1')
INSERT [dbo].[Seat] ([seatId], [seatName]) VALUES (26, N'D2')
INSERT [dbo].[Seat] ([seatId], [seatName]) VALUES (27, N'D3')
INSERT [dbo].[Seat] ([seatId], [seatName]) VALUES (28, N'D4')
INSERT [dbo].[Seat] ([seatId], [seatName]) VALUES (29, N'D5')
INSERT [dbo].[Seat] ([seatId], [seatName]) VALUES (30, N'D6')
INSERT [dbo].[Seat] ([seatId], [seatName]) VALUES (31, N'D7')
INSERT [dbo].[Seat] ([seatId], [seatName]) VALUES (32, N'D8')
INSERT [dbo].[Seat] ([seatId], [seatName]) VALUES (33, N'E1')
INSERT [dbo].[Seat] ([seatId], [seatName]) VALUES (34, N'E2')
INSERT [dbo].[Seat] ([seatId], [seatName]) VALUES (35, N'E3')
INSERT [dbo].[Seat] ([seatId], [seatName]) VALUES (36, N'E4')
INSERT [dbo].[Seat] ([seatId], [seatName]) VALUES (37, N'E5')
INSERT [dbo].[Seat] ([seatId], [seatName]) VALUES (38, N'E6')
INSERT [dbo].[Seat] ([seatId], [seatName]) VALUES (39, N'E7')
INSERT [dbo].[Seat] ([seatId], [seatName]) VALUES (40, N'E8')
INSERT [dbo].[Seat] ([seatId], [seatName]) VALUES (41, N'F1')
INSERT [dbo].[Seat] ([seatId], [seatName]) VALUES (42, N'F2')
INSERT [dbo].[Seat] ([seatId], [seatName]) VALUES (43, N'F3')
INSERT [dbo].[Seat] ([seatId], [seatName]) VALUES (44, N'F4')
INSERT [dbo].[Seat] ([seatId], [seatName]) VALUES (45, N'F5')
INSERT [dbo].[Seat] ([seatId], [seatName]) VALUES (46, N'F6')
INSERT [dbo].[Seat] ([seatId], [seatName]) VALUES (47, N'F7')
INSERT [dbo].[Seat] ([seatId], [seatName]) VALUES (48, N'F8')
SET IDENTITY_INSERT [dbo].[Seat] OFF
GO
SET IDENTITY_INSERT [dbo].[Show] ON 

INSERT [dbo].[Show] ([showId], [showDate], [slotId], [filmId], [roomId], [status]) VALUES (1, CAST(N'2024-03-16' AS Date), 2, 2, 2, 1)
INSERT [dbo].[Show] ([showId], [showDate], [slotId], [filmId], [roomId], [status]) VALUES (2, CAST(N'2023-07-09' AS Date), 1, 1, 3, 1)
INSERT [dbo].[Show] ([showId], [showDate], [slotId], [filmId], [roomId], [status]) VALUES (3, CAST(N'2023-07-09' AS Date), 2, 10, 3, 1)
INSERT [dbo].[Show] ([showId], [showDate], [slotId], [filmId], [roomId], [status]) VALUES (4, CAST(N'2024-08-08' AS Date), 3, 1, 3, 1)
INSERT [dbo].[Show] ([showId], [showDate], [slotId], [filmId], [roomId], [status]) VALUES (5, CAST(N'2024-09-10' AS Date), 9, 1, 2, 1)
INSERT [dbo].[Show] ([showId], [showDate], [slotId], [filmId], [roomId], [status]) VALUES (6, CAST(N'2024-10-25' AS Date), 2, 2, 1, NULL)
INSERT [dbo].[Show] ([showId], [showDate], [slotId], [filmId], [roomId], [status]) VALUES (7, CAST(N'2024-09-09' AS Date), 1, 1, 1, 0)
INSERT [dbo].[Show] ([showId], [showDate], [slotId], [filmId], [roomId], [status]) VALUES (8, CAST(N'2024-10-05' AS Date), 4, 4, 2, 1)
INSERT [dbo].[Show] ([showId], [showDate], [slotId], [filmId], [roomId], [status]) VALUES (9, CAST(N'2024-10-12' AS Date), 1, 1, 1, 1)
INSERT [dbo].[Show] ([showId], [showDate], [slotId], [filmId], [roomId], [status]) VALUES (10, CAST(N'2024-08-08' AS Date), 5, 1, 1, 0)
INSERT [dbo].[Show] ([showId], [showDate], [slotId], [filmId], [roomId], [status]) VALUES (11, CAST(N'2024-08-08' AS Date), 6, 1, 2, 1)
INSERT [dbo].[Show] ([showId], [showDate], [slotId], [filmId], [roomId], [status]) VALUES (12, CAST(N'2024-11-04' AS Date), 2, 1, 2, 1)
INSERT [dbo].[Show] ([showId], [showDate], [slotId], [filmId], [roomId], [status]) VALUES (13, CAST(N'2024-11-05' AS Date), 3, 1, 1, 0)
INSERT [dbo].[Show] ([showId], [showDate], [slotId], [filmId], [roomId], [status]) VALUES (14, CAST(N'2024-11-06' AS Date), 2, 10, 1, 1)
INSERT [dbo].[Show] ([showId], [showDate], [slotId], [filmId], [roomId], [status]) VALUES (15, CAST(N'2024-11-03' AS Date), 6, 2, 2, 1)
INSERT [dbo].[Show] ([showId], [showDate], [slotId], [filmId], [roomId], [status]) VALUES (16, CAST(N'2024-11-02' AS Date), 5, 1, 1, 0)
INSERT [dbo].[Show] ([showId], [showDate], [slotId], [filmId], [roomId], [status]) VALUES (17, CAST(N'2024-07-09' AS Date), 9, 1, 1, 1)
INSERT [dbo].[Show] ([showId], [showDate], [slotId], [filmId], [roomId], [status]) VALUES (18, CAST(N'2024-07-10' AS Date), 1, 1, 1, 1)
INSERT [dbo].[Show] ([showId], [showDate], [slotId], [filmId], [roomId], [status]) VALUES (19, CAST(N'2023-07-17' AS Date), 2, 1, 1, 1)
SET IDENTITY_INSERT [dbo].[Show] OFF
GO
INSERT [dbo].[Slot] ([slotId], [Time]) VALUES (1, N'7:00 AM')
INSERT [dbo].[Slot] ([slotId], [Time]) VALUES (2, N'9:00 AM')
INSERT [dbo].[Slot] ([slotId], [Time]) VALUES (3, N'11:00 AM')
INSERT [dbo].[Slot] ([slotId], [Time]) VALUES (4, N'13:00 PM')
INSERT [dbo].[Slot] ([slotId], [Time]) VALUES (5, N'15:00 PM')
INSERT [dbo].[Slot] ([slotId], [Time]) VALUES (6, N'17:00 PM')
INSERT [dbo].[Slot] ([slotId], [Time]) VALUES (7, N'19: 00 PM')
INSERT [dbo].[Slot] ([slotId], [Time]) VALUES (8, N'21:00 PM')
INSERT [dbo].[Slot] ([slotId], [Time]) VALUES (9, N'23:00 PM')
GO
SET IDENTITY_INSERT [dbo].[user] ON 

INSERT [dbo].[user] ([user_id], [fullname], [email], [password], [gender], [phone], [address], [role], [DOB]) VALUES (1, N'dinh quoc tung', N'tungdqhe160456@fpt.edu.vn', N'202cb962ac59075b964b07152d234b70', 0, N'123456009  ', N'....', 1, CAST(N'2002-08-03' AS Date))
INSERT [dbo].[user] ([user_id], [fullname], [email], [password], [gender], [phone], [address], [role], [DOB]) VALUES (2, N'admin', N'admin@gmail.com', N'202cb962ac59075b964b07152d234b70', 1, N'0378387199 ', N'hong cho anh oi', 0, CAST(N'2001-08-08' AS Date))
INSERT [dbo].[user] ([user_id], [fullname], [email], [password], [gender], [phone], [address], [role], [DOB]) VALUES (3, N'Nguyen Kiem Thong', N'test1@gmail.com', N'202cb962ac59075b964b07152d234b70', 0, N'0886969888 ', N'ko cho 123', 1, CAST(N'2001-08-14' AS Date))
INSERT [dbo].[user] ([user_id], [fullname], [email], [password], [gender], [phone], [address], [role], [DOB]) VALUES (4, N'thong', N'thong2001', N'202cb962ac59075b964b07152d234b70', 1, N'0886969888 ', N'VietNam', 1, CAST(N'2001-08-08' AS Date))
INSERT [dbo].[user] ([user_id], [fullname], [email], [password], [gender], [phone], [address], [role], [DOB]) VALUES (5, N'khanh manh', N'Manhnkhe153424@fpt.edu.vn', N'c4ca4238a0b923820dcc509a6f75849b', 0, N'0375801453 ', N'lâm thao-phú totô', 1, CAST(N'2023-06-29' AS Date))
INSERT [dbo].[user] ([user_id], [fullname], [email], [password], [gender], [phone], [address], [role], [DOB]) VALUES (6, N'aaa', N'user@gmail.com', N'c4ca4238a0b923820dcc509a6f75849b', 1, N'0375801455 ', N'lâm thao-', 1, CAST(N'2023-07-08' AS Date))
INSERT [dbo].[user] ([user_id], [fullname], [email], [password], [gender], [phone], [address], [role], [DOB]) VALUES (7, NULL, N'nguyenthanhlam1070@gmail.com', N'@@@', 0, N'24323423   ', N'qaaa', NULL, CAST(N'2024-03-21' AS Date))
SET IDENTITY_INSERT [dbo].[user] OFF
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_booking_Show] FOREIGN KEY([showId])
REFERENCES [dbo].[Show] ([showId])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_booking_Show]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_booking_user] FOREIGN KEY([userId])
REFERENCES [dbo].[user] ([user_id])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_booking_user]
GO
ALTER TABLE [dbo].[BookingDetails]  WITH CHECK ADD  CONSTRAINT [FK_booking_detail_booking] FOREIGN KEY([bookingId])
REFERENCES [dbo].[Booking] ([bookingId])
GO
ALTER TABLE [dbo].[BookingDetails] CHECK CONSTRAINT [FK_booking_detail_booking]
GO
ALTER TABLE [dbo].[BookingDetails]  WITH CHECK ADD  CONSTRAINT [FK_booking_detail_Seat] FOREIGN KEY([seatId])
REFERENCES [dbo].[Seat] ([seatId])
GO
ALTER TABLE [dbo].[BookingDetails] CHECK CONSTRAINT [FK_booking_detail_Seat]
GO
ALTER TABLE [dbo].[Films]  WITH CHECK ADD  CONSTRAINT [FK_Films_Countries] FOREIGN KEY([CountryCode])
REFERENCES [dbo].[Countries] ([CountryCode])
GO
ALTER TABLE [dbo].[Films] CHECK CONSTRAINT [FK_Films_Countries]
GO
ALTER TABLE [dbo].[Films]  WITH CHECK ADD  CONSTRAINT [FK_Films_Genres] FOREIGN KEY([GenreID])
REFERENCES [dbo].[Genres] ([GenreID])
GO
ALTER TABLE [dbo].[Films] CHECK CONSTRAINT [FK_Films_Genres]
GO
ALTER TABLE [dbo].[Show]  WITH CHECK ADD  CONSTRAINT [FK_Show_Films] FOREIGN KEY([filmId])
REFERENCES [dbo].[Films] ([FilmID])
GO
ALTER TABLE [dbo].[Show] CHECK CONSTRAINT [FK_Show_Films]
GO
ALTER TABLE [dbo].[Show]  WITH CHECK ADD  CONSTRAINT [FK_Show_Rooms] FOREIGN KEY([roomId])
REFERENCES [dbo].[Rooms] ([RoomID])
GO
ALTER TABLE [dbo].[Show] CHECK CONSTRAINT [FK_Show_Rooms]
GO
ALTER TABLE [dbo].[Show]  WITH CHECK ADD  CONSTRAINT [FK_Show_Slot] FOREIGN KEY([slotId])
REFERENCES [dbo].[Slot] ([slotId])
GO
ALTER TABLE [dbo].[Show] CHECK CONSTRAINT [FK_Show_Slot]
GO
