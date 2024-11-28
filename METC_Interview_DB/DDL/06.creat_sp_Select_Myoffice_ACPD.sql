IF OBJECT_ID('sp_Select_Myoffice_ACPD', 'P') IS NULL
BEGIN
    -- 創建 sp_Select_Myoffice_ACPD 存儲過程的 SQL
    EXEC('
        CREATE PROCEDURE sp_Select_Myoffice_ACPD 
@jsonInput NVARCHAR(MAX)  -- 輸入的 JSON 查詢條件
        AS
        BEGIN
            DECLARE @acpd_sid CHAR(20),
                    @logResult NVARCHAR(MAX);
            
            -- 查詢資料
            SELECT * 
            FROM Myoffice_ACPD 
            WHERE acpd_sid = @jsonInput;

            ---- 記錄查詢操作到日志
            --EXEC dbo.usp_AddLog 
            --    @_InBox_ReadID = 0, 
            --    @_InBox_SPNAME = ''sp_Select_Myoffice_ACPD'', 
            --    @_InBox_GroupID = NEWID(), 
            --    @_InBox_ExProgram = ''Select'', 
            --    @_InBox_ActionJSON = @jsonInput, 
            --    @_OutBox_ReturnValues = @logResult OUTPUT;
        END
    ');
END
ELSE
BEGIN
    PRINT 'Stored procedure sp_Select_Myoffice_ACPD already exists.';
END
GO
