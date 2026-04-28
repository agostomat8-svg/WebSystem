<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="ProcessController.Processes.Create" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Create Process</title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>

<form runat="server">

<div class="container mt-5">

    <h2>⚙️ Create New Process</h2>

    <div class="card p-4 mt-3" style="max-width:400px;">

        <label class="form-label">Process Name</label>

        <asp:TextBox ID="txtName" runat="server"
            CssClass="form-control"
            placeholder="Enter process name"></asp:TextBox>

        <br />

        <asp:Button ID="btnCreate" runat="server"
            Text="Create Process"
            CssClass="btn btn-success w-100"
            OnClick="btnCreate_Click" />

        <asp:Label ID="lblMessage" runat="server"
            CssClass="text-danger mt-2"></asp:Label>

    </div>

    <br />

    <!-- BACK BUTTON  -->
    <a href="Index.aspx" class="btn btn-secondary">Back</a>

</div>

</form>

</body>
</html>