<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ProcessController.Processes.Index" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Process Monitoring Dashboard</title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>

<form runat="server">

<div class="container mt-4">

    <h2 class="mb-3">📊 Process Monitoring Dashboard</h2>

    <div class="mb-3">
        <a href="Create.aspx" class="btn btn-success"> Create Process</a>
        <a href="Dashboard.aspx" class="btn btn-info text-white">📈 View Logs</a>
    </div>

    <asp:GridView ID="gvProcesses" runat="server"
        AutoGenerateColumns="False"
        CssClass="table table-bordered table-striped"
        OnRowDataBound="gvProcesses_RowDataBound">

        <Columns>

            <asp:BoundField DataField="ProcessID" HeaderText="ID" />

            <asp:BoundField DataField="ProcessName" HeaderText="Name" />

            <asp:TemplateField HeaderText="State">
                <ItemTemplate>
                    <asp:Label ID="lblState" runat="server"
                        Text='<%# Eval("CurrentState") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>

                    <a href='Run.aspx?id=<%# Eval("ProcessID") %>'
                        class="btn btn-success btn-sm">Run</a>

                    <a href='Wait.aspx?id=<%# Eval("ProcessID") %>'
                        class="btn btn-warning btn-sm">Wait</a>

                    <a href='Terminate.aspx?id=<%# Eval("ProcessID") %>'
                        class="btn btn-danger btn-sm">Terminate</a>

                </ItemTemplate>
            </asp:TemplateField>

        </Columns>

    </asp:GridView>

</div>

</form>

</body>
</html>