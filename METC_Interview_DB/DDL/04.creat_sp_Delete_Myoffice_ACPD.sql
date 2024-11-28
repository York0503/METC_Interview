IF OBJECT_ID('sp_Delete_Myoffice_ACPD', 'P') IS NULL
BEGIN
    -- 創建 Delete 存儲過程
    EXEC('
        CREATE PROCEDURE sp_Delete_Myoffice_ACPD 
            @acpd_sid NVARCHAR(MAX),  -- 輸入的 JSON 刪除條件
			@ReturnCode INT OUTPUT  -- 輸出的返回代碼
        AS
        BEGIN                
            -- 刪除資料
            DELETE FROM Myoffice_ACPD
            WHERE acpd_sid = @acpd_sid;

			-- 設置返回代碼為成功
            SET @ReturnCode = 0;
    
        END
    ');
END
ELSE
BEGIN
    PRINT 'Stored procedure sp_Delete_Myoffice_ACPD already exists.';
END
GO
