<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="ProcessController.Processes.Dashboard" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Process Logs</title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>

<form runat="server">

<div class="container mt-4">

    <!-- TITLE -->
    <h2 class="mb-3">📈 Process Logs (Monitoring)</h2>

    <!-- BACK BUTTON -->
    <a href="Index.aspx" class="btn btn-secondary mb-3">Back to Dashboard</a>

    <!-- LOGS GRID -->
    <asp:GridView ID="gvLogs" runat="server"
        AutoGenerateColumns="False"
        CssClass="table table-dark table-striped table-bordered"
        OnRowDataBound="gvLogs_RowDataBound">

        <Columns>

            <asp:BoundField DataField="LogID" HeaderText="Log ID" />

            <asp:BoundField DataField="ProcessID" HeaderText="Process ID" />

            <asp:TemplateField HeaderText="State">
                <ItemTemplate>
                    <asp:Label ID="lblState" runat="server"
                        Text='<%# Eval("State") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField DataField="Timestamp"
                HeaderText="Timestamp"
                DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" />

        </Columns>

    </asp:GridView>

</div>

</form>

</body>
</html>