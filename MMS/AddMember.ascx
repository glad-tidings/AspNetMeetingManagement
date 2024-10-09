<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="AddMember.ascx.vb" Inherits="MMS.AddMember" %>

<h3>افزودن عضو جدید</h3>
<label id="lblError" runat="server" class="error-label"></label>
<table class="view-tbl">
    <tr>
        <td class="add-td">نام و نام خانوادگی :</td>
        <td class="add-td-2"><input id="MeName" size="40" type="text" runat="server" /></td>
    </tr>
    <tr>
        <td class="add-td">تلفن تماس :</td>
        <td class="add-td-2"><input dir="ltr" id="MeTel" size="20" type="text" runat="server" /></td>
    </tr>
    <tr>
        <td class="add-td">موبایل :</td>
        <td class="add-td-2"><input dir="ltr" id="MeMobile" size="30" type="text" runat="server" /></td>
    </tr>
    <tr>
        <td></td>
        <td class="add-td-2"><asp:Button ID="AddMember" runat="server" Text="افزودن" /></td>
    </tr>
</table>