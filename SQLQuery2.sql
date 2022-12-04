update librarian 
set photo = (SELECT MyImage.* from Openrowset(Bulk 'C:\Users\ibati\OneDrive\Рабочий стол\для курсача\аннаа.jpg', Single_Blob) MyImage) where id = 92
