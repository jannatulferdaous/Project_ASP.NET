USE [master]
GO
/****** Object:  Database [Quizgame]    Script Date: 2/7/2024 9:22:30 AM ******/
CREATE DATABASE [Quizgame]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Quizgame', FILENAME = N'C:\Users\Jannatul Ferdaous\Quizgame.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Quizgame_log', FILENAME = N'C:\Users\Jannatul Ferdaous\Quizgame_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Quizgame] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Quizgame].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Quizgame] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Quizgame] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Quizgame] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Quizgame] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Quizgame] SET ARITHABORT OFF 
GO
ALTER DATABASE [Quizgame] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Quizgame] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Quizgame] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Quizgame] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Quizgame] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Quizgame] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Quizgame] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Quizgame] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Quizgame] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Quizgame] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Quizgame] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Quizgame] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Quizgame] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Quizgame] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Quizgame] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Quizgame] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Quizgame] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Quizgame] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Quizgame] SET  MULTI_USER 
GO
ALTER DATABASE [Quizgame] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Quizgame] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Quizgame] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Quizgame] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Quizgame] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Quizgame] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Quizgame] SET QUERY_STORE = OFF
GO
USE [Quizgame]
GO
/****** Object:  Table [dbo].[Answer]    Script Date: 2/7/2024 9:22:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[QuestionId] [int] NOT NULL,
	[Answer] [varchar](128) NOT NULL,
	[IsCorrect] [bit] NOT NULL,
 CONSTRAINT [PK_Answer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Question]    Script Date: 2/7/2024 9:22:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question](
	[QuestionId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[Question] [text] NOT NULL,
	[ArticleId] [int] NOT NULL,
 CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED 
(
	[QuestionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Question_answerMap]    Script Date: 2/7/2024 9:22:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question_answerMap](
	[UserId] [int] NOT NULL,
	[QuestionId] [int] NOT NULL,
	[AnswerId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tutorial]    Script Date: 2/7/2024 9:22:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tutorial](
	[ArticleId] [int] IDENTITY(1,1) NOT NULL,
	[Language] [varchar](50) NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[Article] [text] NOT NULL,
	[OrderBy] [int] NULL,
 CONSTRAINT [PK_Tutorial] PRIMARY KEY CLUSTERED 
(
	[ArticleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 2/7/2024 9:22:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User_Tutorial]    Script Date: 2/7/2024 9:22:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Tutorial](
	[UserId] [int] NOT NULL,
	[ArticleId] [int] NOT NULL,
 CONSTRAINT [PK_User_Tutorial] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Answer] ADD  CONSTRAINT [DF_Answer_IsCorrect]  DEFAULT ((0)) FOR [IsCorrect]
GO
ALTER TABLE [dbo].[Answer]  WITH CHECK ADD  CONSTRAINT [FK_Question_Answer] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Question] ([QuestionId])
GO
ALTER TABLE [dbo].[Answer] CHECK CONSTRAINT [FK_Question_Answer]
GO
ALTER TABLE [dbo].[Question_answerMap]  WITH CHECK ADD  CONSTRAINT [FK_Question_answerMap_Answer] FOREIGN KEY([AnswerId])
REFERENCES [dbo].[Answer] ([Id])
GO
ALTER TABLE [dbo].[Question_answerMap] CHECK CONSTRAINT [FK_Question_answerMap_Answer]
GO
ALTER TABLE [dbo].[Question_answerMap]  WITH CHECK ADD  CONSTRAINT [FK_Question_answerMap_Question] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Question] ([QuestionId])
GO
ALTER TABLE [dbo].[Question_answerMap] CHECK CONSTRAINT [FK_Question_answerMap_Question]
GO
ALTER TABLE [dbo].[Question_answerMap]  WITH CHECK ADD  CONSTRAINT [FK_Question_answerMap_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Question_answerMap] CHECK CONSTRAINT [FK_Question_answerMap_User]
GO
ALTER TABLE [dbo].[User_Tutorial]  WITH CHECK ADD  CONSTRAINT [FK_User_Tutorial_Tutorial] FOREIGN KEY([ArticleId])
REFERENCES [dbo].[Tutorial] ([ArticleId])
GO
ALTER TABLE [dbo].[User_Tutorial] CHECK CONSTRAINT [FK_User_Tutorial_Tutorial]
GO
/****** Object:  StoredProcedure [dbo].[AnswerView]    Script Date: 2/7/2024 9:22:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AnswerView]
	@Id inT
AS
BEGIN
	SET NOCOUNT ON;
	SELECT [Id]
		, [QuestionId]
		, [Answer]
		, [IsCorrect]
  FROM [Quizgame].[dbo].[Answer]
   
  where [Id] = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[CreateAnswer]    Script Date: 2/7/2024 9:22:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateAnswer]

	 @QuestionId int
	, @Answer varchar(128)
	, @IsCorrect bit
AS
BEGIN
	SET NOCOUNT ON;
	insert into Answer( [QuestionId], [Answer],[IsCorrect])
	values ( @QuestionId, @Answer, @IsCorrect )
END
GO
/****** Object:  StoredProcedure [dbo].[CreateQuestion]    Script Date: 2/7/2024 9:22:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateQuestion]

	@Title varchar(50)
	, @Question Text
	,@ArticleId int
	
AS
BEGIN
	SET NOCOUNT ON;
	insert into Question([Title], [Question],[ArticleId])
	values (  @Title , @Question,@ArticleId)
END
GO
/****** Object:  StoredProcedure [dbo].[CreateQuestion_answerMap]    Script Date: 2/7/2024 9:22:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateQuestion_answerMap]
	@UserId int, 
	@QuestionAnswer VARCHAR(MAX)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @QuestionAnswers TABLE
	(
		UserId INT NULL
		, QuestionAnswer VARCHAR(128) NULL
		, Question AS LEFT(QuestionAnswer, CHARINDEX('=', QuestionAnswer) - 1)
		, Answer AS Right(QuestionAnswer, CHARINDEX('=', (REVERSE(QuestionAnswer)))-1)
		, UpdateNeeded BIT DEFAULT(0)
	)

	INSERT INTO @QuestionAnswers (UserId, QuestionAnswer)
	SELECT @UserId, [value] 
	FROM STRING_SPLIT(@QuestionAnswer , ',')

	UPDATE @QuestionAnswers
	SET UpdateNeeded = 1
	FROM Question_answerMap QAM INNER JOIN @QuestionAnswers QA
	ON QA.UserId = QAM.UserId AND QA.Question = QAM.QuestionId

	UPDATE Question_answerMap
	SET AnswerId = QA.Answer
	FROM @QuestionAnswers QA
	WHERE QA.UpdateNeeded = 1

	INSERT INTO Question_answerMap (UserId, QuestionId, AnswerId)
	SELECT QA.UserId, QA.Question, QA.Answer
	FROM @QuestionAnswers QA
	WHERE QA.UpdateNeeded = 0
END
GO
/****** Object:  StoredProcedure [dbo].[CreateTutorial]    Script Date: 2/7/2024 9:22:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateTutorial]
	 
	 @Language varchar(50)
	, @Title varchar(50)
	, @Article  Text
AS
BEGIN
	SET NOCOUNT ON;
	insert into Tutorial( [Language], [Title], [Article])
	values (@Language, @Title , @Article)
END
GO
/****** Object:  StoredProcedure [dbo].[CreateUser_Tutorial]    Script Date: 2/7/2024 9:22:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[CreateUser_Tutorial]
	@UserId int, 
	 @ArticleId int
AS
BEGIN
	SET NOCOUNT ON;
	insert into User_Tutorial( [UserId], [ArticleId])
	values(@UserId, @ArticleId)
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteAnswerbyId]    Script Date: 2/7/2024 9:22:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
 create PROCEDURE [dbo].[DeleteAnswerbyId]
	@Id int 
	 
AS
BEGIN
	SET NOCOUNT ON;
	Delete from Answer
	where  Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteQuestionbyId]    Script Date: 2/7/2024 9:22:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteQuestionbyId]
	@QuestionId int 
	 
AS
BEGIN
	SET NOCOUNT ON;
	Delete from Question
	where  QuestionId = @QuestionId
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteTutorialbyId]    Script Date: 2/7/2024 9:22:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[DeleteTutorialbyId]
	@ArticleId int 
	 
AS
BEGIN
	SET NOCOUNT ON;
	Delete from Tutorial
	where ArticleId = @ArticleId
END
GO
/****** Object:  StoredProcedure [dbo].[EditAnswer]    Script Date: 2/7/2024 9:22:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[EditAnswer]
	@Id int 
	, @QuestionId int
	, @Answer varchar(128)
	, @IsCorrect bit
AS
BEGIN
	SET NOCOUNT ON;
	Update Answer
	set   
	 
	[QuestionId] = @QuestionId,
	[Answer]= @Answer ,
	 [IsCorrect]= @IsCorrect
	 
	
	where[Id] = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[EditQuestion]    Script Date: 2/7/2024 9:22:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditQuestion]
	@QuestionId int, 
  @Title varchar(50),
 @Question  Text,
	@ArticleId int
AS
BEGIN
	SET NOCOUNT ON;
	Update Question
	set   
	[Title] = @Title, 
	[Question] = @Question,
	[ArticleId]= @ArticleId
	where[QuestionId] = @QuestionId
END
GO
/****** Object:  StoredProcedure [dbo].[EditTutorial]    Script Date: 2/7/2024 9:22:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[EditTutorial]
      @ArticleId int
	 , @Language varchar(50)
	, @Title varchar(50)
	, @Article  Text
AS
BEGIN
	SET NOCOUNT ON;
	 
	Update Tutorial
	set [Language] = @Language, 
	[Title] = @Title, 
	[Article] = @Article
	where [ArticleId] = @ArticleId
END
GO
/****** Object:  StoredProcedure [dbo].[EditUser_Tutorial]    Script Date: 2/7/2024 9:22:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[EditUser_Tutorial]
	@UserId int 
	, @ArticleId int 
	 
AS
BEGIN
	SET NOCOUNT ON;
	Update User_Tutorial
	set  
	 
	[ArticleId] = @ArticleId
	where [UserId] = @UserId
END
GO
/****** Object:  StoredProcedure [dbo].[GetAnswers]    Script Date: 2/7/2024 9:22:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAnswers] 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT
	     [Id]
		, [QuestionId]
		, [Answer],
		[IsCorrect]
  FROM [Quizgame].[dbo].[Answer]
END
GO
/****** Object:  StoredProcedure [dbo].[GetQuestions]    Script Date: 2/7/2024 9:22:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[GetQuestions] 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT
	[QuestionId]
		, [Title]
		, [Question],
		[ArticleId]
  FROM [Quizgame].[dbo].[Question]
END
GO
/****** Object:  StoredProcedure [dbo].[GetTutorial]    Script Date: 2/7/2024 9:22:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[GetTutorial] 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT [ArticleId]
		, [Language]
		, [Title]
		, [Article]
		
  FROM [Quizgame].[dbo].[Tutorial]
END
GO
/****** Object:  StoredProcedure [dbo].[lastArticle]    Script Date: 2/7/2024 9:22:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[lastArticle]
  	
AS
BEGIN
	SELECT TOP 1 * FROM Tutorial ORDER BY ArticleId DESC
	SELECT T.ArticleId, T.Language, T.Title, T.Article FROM Tutorial AS T
	--INNER JOIN User_Tutorial AS UT on T.ArticleId = UT.ArticleId
	--WHERE UT.UserId = @UserId	
END
GO
/****** Object:  StoredProcedure [dbo].[NextArticle]    Script Date: 2/7/2024 9:22:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[NextArticle]
 
	 @QuestionId int,
	 @UserId int
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @articalID INT;
	Declare @orderby int;
	Declare @nextOrderby int; 
	Declare @nextArticalId int;

	SELECT top 1 @articalID = ArticleId
	from Question where [QuestionId]= @QuestionId

	SELECT top 1 @orderby = OrderBy
  	FROM [Quizgame].[dbo].[Tutorial]
	where ArticleId = @articalID
	
	SELECT top 1 @nextOrderby = OrderBy
  	FROM [Quizgame].[dbo].[Tutorial]
	where OrderBy > @orderby
	order by [OrderBy]

	if @nextOrderby is not null and @nextOrderby > 0
	Begin
		SELECT top 1 @nextArticalId = ArticleId
  		FROM [Quizgame].[dbo].[Tutorial]
		where OrderBy = @nextOrderby

		IF @nextArticalId <> @articalID
		BEGIN
			Update User_Tutorial 
			Set ArticleId = @nextArticalId
			where UserId = @UserId		
		END		 
	END 
	ELSE
	BEGIN
		Update User_Tutorial 
		Set ArticleId =1
		where UserId = @UserId		
	END
END
GO
/****** Object:  StoredProcedure [dbo].[Ques_answerMap]    Script Date: 2/7/2024 9:22:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[Ques_answerMap]
	 
	 @QuestionId int,
	 @AnswerId  int
AS
BEGIN
	SET NOCOUNT ON;
	insert into Question_answerMap( [QuestionId],[AnswerId])
	values( @QuestionId,@AnswerId)
END
GO
/****** Object:  StoredProcedure [dbo].[Questionshow]    Script Date: 2/7/2024 9:22:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Questionshow]
 
	 @ArticleId int
AS
BEGIN
	SET NOCOUNT ON;
	
	 SELECT Tutorial.ArticleId, Question.Question,Question.QuestionId, Answer.Answer,Answer.Id as AnswerId, Answer.IsCorrect
FROM Tutorial
INNER JOIN Question ON Tutorial.ArticleId = Question.ArticleId
INNER JOIN  Answer ON Question.QuestionId = Answer.QuestionId
where Tutorial.ArticleId=@ArticleId
order by Question.QuestionId, Answer.Id
END
GO
/****** Object:  StoredProcedure [dbo].[QuestionView]    Script Date: 2/7/2024 9:22:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[QuestionView]
	@questionId inT
AS
BEGIN
	SET NOCOUNT ON;
	SELECT [QuestionId]
		 
		, [Question]
		,[ArticleId]	 
  FROM [Quizgame].[dbo].[Question]
   
  where [QuestionId] = @questionId
END
GO
/****** Object:  StoredProcedure [dbo].[Resultshow]    Script Date: 2/7/2024 9:22:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Resultshow]

AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @RowCount int;
	Select @RowCount = COUNT(*) 
	FROM Question_answerMap INNER JOIN  Answer ON Question_answerMap.AnswerId = Answer.Id
	where Answer.IsCorrect = 1;

	Select @RowCount AS 'RowCount'

END
GO
/****** Object:  StoredProcedure [dbo].[UserArticle]    Script Date: 2/7/2024 9:22:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UserArticle]
	@UserId int 
AS
BEGIN
	SET NOCOUNT ON;

	IF NOT EXISTS (
		SELECT * FROM User_Tutorial
		WHERE [UserId] = @UserId
	)
	BEGIN
		DECLARE @articalID INT;
		SELECT top 1 @articalID = ArticleId from Tutorial order by ArticleId ASC

		IF @articalID > 0
		BEGIN
			INSERT INTO User_Tutorial (UserId, ArticleId)
			Values (@UserId, @articalID)
		END
	END
	
	SELECT T.ArticleId, T.Language, T.Title, T.Article FROM Tutorial AS T
	INNER JOIN User_Tutorial AS UT on T.ArticleId = UT.ArticleId
	WHERE UT.UserId = @UserId	
END
GO
/****** Object:  StoredProcedure [dbo].[ValidUser]    Script Date: 2/7/2024 9:22:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ValidUser]
	@Name varchar(50)  
	, @Password varchar(50)
	
AS
BEGIN
	SELECT [UserId], [Name], [Password]
	FROM [Quizgame].[dbo].[User]
	WHERE [Name] = @Name and [Password] = @Password
END
GO
/****** Object:  StoredProcedure [dbo].[ViewById]    Script Date: 2/7/2024 9:22:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ViewById]
	@ArticleId inT
AS
BEGIN
	SET NOCOUNT ON;
	SELECT [ArticleId]
		, [Language]
		, [Title]
		, [Article]
		 
  FROM [Quizgame].[dbo].[Tutorial]
  where [ArticleId] = @ArticleId
END
GO
USE [master]
GO
ALTER DATABASE [Quizgame] SET  READ_WRITE 
GO
