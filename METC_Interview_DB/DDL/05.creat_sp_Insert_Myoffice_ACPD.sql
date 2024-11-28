IF OBJECT_ID('sp_Insert_Myoffice_ACPD', 'P') IS NULL
BEGIN
    -- 創建存儲過程
    EXEC('
        CREATE PROCEDURE sp_Insert_Myoffice_ACPD
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
            @logResult NVARCHAR(MAX),
            @ReturnCode INT OUTPUT  -- 輸出的返回代碼
        AS
        BEGIN
            BEGIN TRY      
                -- 插入資料
                INSERT INTO Myoffice_ACPD 
                (
                    acpd_sid, acpd_cname, acpd_ename, acpd_sname, acpd_email, acpd_status, 
                    acpd_stop, acpd_stopMemo, acpd_LoginID, acpd_LoginPW, acpd_memo, 
                    acpd_nowdatetime, appd_nowid, acpd_upddatetitme, acpd_updid
                )
                VALUES
                (
                    @acpd_sid, @acpd_cname, @acpd_ename, @acpd_sname, @acpd_email, @acpd_status, 
                    @acpd_stop, @acpd_stopMemo, @acpd_LoginID, @acpd_LoginPW, @acpd_memo, 
                    @acpd_nowdatetime, @appd_nowid, @acpd_upddatetitme, @acpd_updid
                );

                ---- 記錄插入操作訊息
                --EXEC dbo.usp_AddLog 
                --    @_InBox_ReadID = 0, 
                --    @_InBox_SPNAME = ''sp_Insert_Myoffice_ACPD'', 
                --    @_InBox_GroupID = NEWID(), 
                --    @_InBox_ExProgram = ''Insert'', 
                --    @_InBox_ActionJSON = @jsonInput, 
                --    @_OutBox_ReturnValues = @logResult OUTPUT;

                -- 設置返回代碼為成功
                SET @ReturnCode = 0;
                
                -- 如果成功，返回成功
                PRINT ''Insert successful.'';  -- 這行可以省略，根據需要保留
                
            END TRY
            BEGIN CATCH
                -- 處理錯誤
                SET @ReturnCode = 1;
                PRINT ''Insert failed.'';
                ---- 記錄錯誤訊息
                --EXEC dbo.usp_AddLog 
                --    @_InBox_ReadID = 0, 
                --    @_InBox_SPNAME = ''sp_Insert_Myoffice_ACPD'', 
                --    @_InBox_GroupID = NEWID(), 
                --    @_InBox_ExProgram = ''Insert failed'', 
                --    @_InBox_ActionJSON = ERROR_MESSAGE(), 
                --    @_OutBox_ReturnValues = @logResult OUTPUT;
            END CATCH
        END

    ');
END
ELSE
BEGIN
    PRINT 'Stored procedure sp_Insert_Myoffice_ACPD already exists.';
END
GO
