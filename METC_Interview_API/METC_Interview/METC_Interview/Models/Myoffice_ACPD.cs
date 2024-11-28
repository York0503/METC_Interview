namespace METC_Interview.Models
{
    public class Myoffice_ACPD
    {
    }
    /// <summary>
    /// 刪除ACPD
    /// </summary>
    public class Delete_Myoffice_ACPD
    {
        public string acpd_sid { get; set; }
    }
    /// <summary>
    /// 新增ACPD
    /// </summary>
    public class Insert_Myoffice_ACPD
    {
        /// <summary>
        /// 使用者主鍵
        /// </summary>
        public string acpd_sid { get; set; } // CHAR(20)

        /// <summary>
        /// 中文名稱
        /// </summary>
        public string acpd_cname { get; set; } // NVARCHAR(60)

        /// <summary>
        /// 英文名稱
        /// </summary>
        public string acpd_ename { get; set; } // NVARCHAR(40)

        /// <summary>
        /// 簡稱
        /// </summary>
        public string acpd_sname { get; set; } // NVARCHAR(40)

        /// <summary>
        /// 使用者信箱
        /// </summary>
        public string acpd_email { get; set; } // NVARCHAR(60)

        /// <summary>
        /// 狀況 0=正常, 99=不正常
        /// </summary>
        public byte acpd_status { get; set; } // TINYINT

        /// <summary>
        /// 是否停用/不可登入
        /// </summary>
        public bool acpd_stop { get; set; } // BIT

        /// <summary>
        /// 停用原因
        /// </summary>
        public string acpd_stopMemo { get; set; } // NVARCHAR(600)

        /// <summary>
        /// 登入帳號
        /// </summary>
        public string acpd_LoginID { get; set; } // NVARCHAR(30)

        /// <summary>
        /// 登入密碼
        /// </summary>
        public string acpd_LoginPW { get; set; } // NVARCHAR(60)

        /// <summary>
        /// 備註
        /// </summary>
        public string acpd_memo { get; set; } // NVARCHAR(120)

        /// <summary>
        /// 新增日期
        /// </summary>
        public DateTime acpd_nowdatetime { get; set; } // DATETIME

        /// <summary>
        /// 新增人員代碼
        /// </summary>
        public string appd_nowid { get; set; } // NVARCHAR(20)

        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime acpd_upddatetitme { get; set; } // DATETIME

        /// <summary>
        /// 修改人員代碼
        /// </summary>
        public string acpd_updid { get; set; } // NVARCHAR(20)

        /// <summary>
        /// 記錄日誌結果
        /// </summary>
        public string logResult { get; set; } // NVARCHAR(MAX)

    }

    /// <summary>
    /// 查詢ACPD
    /// </summary>
    public class Select_Myoffice_ACPD
    {
        public string acpd_sid { get; set; }
        public string acpd_cname { get; set; }
    }

    /// <summary>
    /// 修改ACPD
    /// </summary>
    public class Update_Myoffice_ACPD
    {
        /// <summary>
        /// 使用者主鍵
        /// </summary>
        public string acpd_sid { get; set; } // CHAR(20)

        /// <summary>
        /// 中文名稱
        /// </summary>
        public string acpd_cname { get; set; } // NVARCHAR(60)

        /// <summary>
        /// 英文名稱
        /// </summary>
        public string acpd_ename { get; set; } // NVARCHAR(40)

        /// <summary>
        /// 簡稱
        /// </summary>
        public string acpd_sname { get; set; } // NVARCHAR(40)

        /// <summary>
        /// 使用者信箱
        /// </summary>
        public string acpd_email { get; set; } // NVARCHAR(60)

        /// <summary>
        /// 狀況 0=正常, 99=不正常
        /// </summary>
        public byte acpd_status { get; set; } // TINYINT

        /// <summary>
        /// 是否停用/不可登入
        /// </summary>
        public bool acpd_stop { get; set; } // BIT

        /// <summary>
        /// 停用原因
        /// </summary>
        public string acpd_stopMemo { get; set; } // NVARCHAR(600)

        /// <summary>
        /// 登入帳號
        /// </summary>
        public string acpd_LoginID { get; set; } // NVARCHAR(30)

        /// <summary>
        /// 登入密碼
        /// </summary>
        public string acpd_LoginPW { get; set; } // NVARCHAR(60)

        /// <summary>
        /// 備註
        /// </summary>
        public string acpd_memo { get; set; } // NVARCHAR(120)

        /// <summary>
        /// 新增日期
        /// </summary>
        public DateTime acpd_nowdatetime { get; set; } // DATETIME

        /// <summary>
        /// 新增人員代碼
        /// </summary>
        public string appd_nowid { get; set; } // NVARCHAR(20)

        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime acpd_upddatetitme { get; set; } // DATETIME

        /// <summary>
        /// 修改人員代碼
        /// </summary>
        public string acpd_updid { get; set; } // NVARCHAR(20)

        /// <summary>
        /// 記錄日誌結果
        /// </summary>
        public string logResult { get; set; } // NVARCHAR(MAX)
    }
}
