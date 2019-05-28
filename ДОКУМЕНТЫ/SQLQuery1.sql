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