IF OBJECT_ID('sp_Update_Myoffice_ACPD', 'P') IS NULL
BEGIN
    -- 創建 Update 存儲過程
    EXEC('
        CREATE PROCEDURE sp_Update_Myoffice_ACPD 
            @acpd_sid CHAR(20),
            @acpd_cname NVARCHAR(60),
            @acpd_ename NVARCHAR(40),
            @acpd_sname NVARCHAR(40),
            @acpd_email NVARCHAR(60),
            @acpd_status TINYINT,
            @acpd_stop BIT,
            @acpd_stopMemo NVARCHAR(600),
            @acpd_LoginID NVARCHAR(30),
            @acpd_LoginPW NVARCHAR(60),
            @acpd_memo NVARCHAR(120),
            @acpd_nowdatetime DATETIME,
            @appd_nowid NVARCHAR(20),
            @acpd_upddatetitme DATETIME,
            @acpd_updid NVARCHAR(20),
            @logResult NVARCHAR(MAX),  -- 輸入的 JSON 字符串
            @ReturnCode INT OUTPUT  -- 輸出的返回代碼
        AS
        BEGIN
            -- 更新資料
            UPDATE Myoffice_ACPD
            SET
                acpd_cname = @acpd_cname,
                acpd_ename = @acpd_ename,
                acpd_sname = @acpd_sname,
                acpd_email = @acpd_email,
                acpd_status = @acpd_status,
                acpd_stop = @acpd_stop,
                acpd_stopMemo = @acpd_stopMemo,
                acpd_LoginID = @acpd_LoginID,
                acpd_LoginPW = @acpd_LoginPW,
                acpd_memo = @acpd_memo,
                acpd_nowdatetime = @acpd_nowdatetime,
                appd_nowid = @appd_nowid,
                acpd_upddatetitme = @acpd_upddatetitme,
                acpd_updid = @acpd_updid
            WHERE acpd_sid = @acpd_sid;
            
            -- 設置返回代碼為成功
            SET @ReturnCode = 0;
        END
    ');
END
ELSE
BEGIN
    PRINT 'Stored procedure sp_Update_Myoffice_ACPD already exists.';
END
GO
