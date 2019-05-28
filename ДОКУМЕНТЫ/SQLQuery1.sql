SELECT [SafeName], [UserIsCreator], [FieldOne], [FieldTwo],
	   [FieldThree], [FieldFour], [FieldFive], [FieldSix]
FROM [User-Safe] us 
INNER JOIN [Safe] s ON us.[Safe_ID] = s.[Safe_ID]
INNER JOIN [Category] ct ON ct.[Category_ID] = s.[Category_ID]
INNER JOIN [User] u ON u.[User_ID] = us.[User_ID]
WHERE [Email] = 'admin@gmail.com'


SELECT [SafeName], dbo.GetSafeCreator(us.[Safe_ID]) Creator, us.[Safe_ID], [FieldOne], [FieldTwo],
	   [FieldThree], [FieldFour], [FieldFive], [FieldSix]
FROM [User-Safe] us 
INNER JOIN [Safe] s ON us.[Safe_ID] = s.[Safe_ID]
INNER JOIN [Category] ct ON ct.[Category_ID] = s.[Category_ID]
INNER JOIN [User] u ON u.[User_ID] = us.[User_ID]
WHERE [Email] = 'admin@gmail.com'










SELECT us.[Safe_ID]
FROM [User-Safe] us
INNER JOIN [Safe] s ON us.[Safe_ID] = s.[Safe_ID]
INNER JOIN [User] u ON u.[User_ID] = us.[User_ID]
WHERE s.[SafeName] = 'Пароли' 


SELECT f.[Folder_ID], [FolderName], [Email]
FROM [Folder-Safe] fs
INNER JOIN [Folder] f ON fs.[Folder_ID] = f.[Folder_ID]
INNER JOIN [User] u ON f.[User_ID] = u.[User_ID]
WHERE fs.[Safe_ID] = 19

SELECT COUNT(us.[User-Safe_ID])
FROM [User-Safe] us
WHERE us.[Safe_ID] = 20




DECLARE @CatID int;
DECLARE @safeID int;
SET @safeID = 26
SET @CatID = (
   SELECT ct.[Category_ID]
   FROM [Safe] s
   INNER JOIN [Category] ct ON s.[Category_ID] = ct.[Category_ID]
   WHERE s.[Safe_ID] = @safeID
)
DELETE
FROM [User-Safe]
WHERE [Safe_ID] = @safeID AND [UserIsCreator] = 'True';
DELETE
FROM [Safe]
WHERE [Safe_ID] = @safeID;
DELETE
FROM [Category]
WHERE [Category_ID] = @CatID;
DECLARE @FolderID int;
SET @FolderID = (
	SELECT fs.[Folder_ID]
	FROM [Folder-Safe] fs
	WHERE fs.[Safe_ID] = @safeID
)
DELETE 
FROM [Folder-Safe] 
WHERE [Folder_ID] = @FolderID;
DELETE 
FROM [Folder] 
WHERE [Folder_ID] = @FolderID;




DECLARE @CatID int;
DECLARE @safe int;
SET @safe = 25
SET @CatID = (
   SELECT ct.[Category_ID]
   FROM [Safe] s
   INNER JOIN [Category] ct ON s.[Category_ID] = ct.[Category_ID]
   WHERE s.[Safe_ID] = @safe
)
DELETE
FROM [User-Safe]
WHERE [Safe_ID] = @safe AND [UserIsCreator] = 'True';
DELETE
FROM [Safe]
WHERE [Safe_ID] = @safe;
DELETE
FROM [Category]
WHERE [Category_ID] = @CatID;
DECLARE @FolderID int;
SET @FolderID = (
     SELECT fs.[Folder_ID]
     FROM [Folder-Safe] fs
     WHERE fs.[Safe_ID] = @safe
)
DELETE
FROM [Folder-Safe]
WHERE [Folder_ID] = @FolderID;
DELETE
FROM [Folder]
WHERE [Folder_ID] = @FolderID;