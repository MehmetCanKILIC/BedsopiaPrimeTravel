<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Bedsopia_Prime_Travel.WebForm1" %>



<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="js/jquery.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#btnGetEmployee').click(function () {
                var empId = $('#txtId').val();
                $.ajax({
                    url: '/WebForm1.aspx/GetEmployeeById',
                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    data: '{employeeId:' + empId + '}',
                    dataType: "json",
                    success: function (data) {
                        console.log(data);
                        $('#txtName').val(data.d.Name);
                        $('#txtGender').val(data.d.Gender);
                        $('#txtSalary').val(data.d.Salary);
                    },
                    failure: function (response) {
                        alert(response.d);
                    }
                });

                //$.ajax({
                //    type: "POST",
                //    url: '/Default.aspx/TestMethod',
                //    data: '{message: "HAI" }',
                //    contentType: "application/json; charset=utf-8",
                //    success: function (data) {
                //        console.log(data);
                //    },
                //    failure: function (response) {
                //        alert(response.d);
                //    }
                //});
            });
        });
    </script>
</head>
<body style="font-family: Arial">
    <form id="form1" runat="server">
        ID :
        <input id="txtId" type="text" style="width: 86px" />
<%--        <input type="button" id="btnGetEmployee" value="Get Employee" />--%>
        <asp:LinkButton ID="btnGetEmployee" runat="server" CssClass="btn bg-grey waves-effect"><i class="material-icons">check</i></asp:LinkButton>
        <br />
        <br />
        <table border="1" style="border-collapse: collapse">
            <tr>
                <td>Name</td>
                <td>
                    <input id="txtName" type="text" /></td>
            </tr>
            <tr>
                <td>Gender</td>
                <td>
                    <input id="txtGender" type="text" /></td>
            </tr>
            <tr>
                <td>Salary</td>
                <td>
                    <input id="txtSalary" type="text" /></td>
            </tr>
        </table>
    </form>
</body>
</html>
