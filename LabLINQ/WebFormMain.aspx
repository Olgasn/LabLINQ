﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormMain.aspx.cs" Inherits="LabLINQ.WebFormMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Использование технологий доступа к данным – LINQ и ENTITY FRAMEWORK</title>
</head>
<body>
    <form id="formMain" runat="server">
    <div>
    
        <asp:GridView ID="gridLINQVisualize" runat="server" AllowPaging="True" OnPageIndexChanging="gridLINQVisualize_PageIndexChanging">
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
