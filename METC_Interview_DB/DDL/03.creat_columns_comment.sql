-- 為 `Myoffice_ACPD` 表中的各欄位新增或更新描述

-- acpd_cname
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Myoffice_ACPD' AND COLUMN_NAME = 'acpd_cname')
BEGIN             
    IF NOT EXISTS (SELECT 1 FROM fn_listextendedproperty(N'MS_Description', 'SCHEMA', 'dbo', 'TABLE', 'Myoffice_ACPD', 'COLUMN', 'acpd_cname'))
    BEGIN
        EXEC sys.sp_addextendedproperty 
            @name = N'MS_Description', 
            @value = N'使用者中文名稱', 
            @level0type = N'SCHEMA', 
            @level0name = N'dbo', 
            @level1type = N'TABLE', 
            @level1name = N'Myoffice_ACPD', 
            @level2type = N'COLUMN', 
            @level2name = N'acpd_cname'
    END
    ELSE
    BEGIN
        EXEC sys.sp_updateextendedproperty 
            @name = N'MS_Description', 
            @value = N'使用者中文名稱', 
            @level0type = N'SCHEMA', 
            @level0name = N'dbo', 
            @level1type = N'TABLE', 
            @level1name = N'Myoffice_ACPD', 
            @level2type = N'COLUMN', 
            @level2name = N'acpd_cname'
    END
END
ELSE
BEGIN
    PRINT('Error Table: Myoffice_ACPD')
END
GO

-- acpd_status
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Myoffice_ACPD' AND COLUMN_NAME = 'acpd_status')
BEGIN             
    IF NOT EXISTS (SELECT 1 FROM fn_listextendedproperty(N'MS_Description', 'SCHEMA', 'dbo', 'TABLE', 'Myoffice_ACPD', 'COLUMN', 'acpd_status'))
    BEGIN
        EXEC sys.sp_addextendedproperty 
            @name = N'MS_Description', 
            @value = N'使用者狀態：0=正常, 99=不正常', 
            @level0type = N'SCHEMA', 
            @level0name = N'dbo', 
            @level1type = N'TABLE', 
            @level1name = N'Myoffice_ACPD', 
            @level2type = N'COLUMN', 
            @level2name = N'acpd_status'
    END
    ELSE
    BEGIN
        EXEC sys.sp_updateextendedproperty 
            @name = N'MS_Description', 
            @value = N'使用者狀態：0=正常, 99=不正常', 
            @level0type = N'SCHEMA', 
            @level0name = N'dbo', 
            @level1type = N'TABLE', 
            @level1name = N'Myoffice_ACPD', 
            @level2type = N'COLUMN', 
            @level2name = N'acpd_status'
    END
END
ELSE
BEGIN
    PRINT('Error Table: Myoffice_ACPD')
END
GO
