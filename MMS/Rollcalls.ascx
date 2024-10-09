<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Rollcalls.ascx.vb" Inherits="MMS.Rollcalls" %>

<h3>حضور و غیاب</h3>
<label id="lblError" runat="server" class="error-label"></label>
<table class="view-tbl">
    <tr>
        <td class="add-td">جلسه :</td>
        <td class="add-td-2">
            <asp:DropDownList ID="MTitle" Width="200px" runat="server" AutoPostBack="True"></asp:DropDownList>
            <asp:DropDownList ID="MIndex" Visible="false" runat="server"></asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="add-td">اعضا :</td>
        <td class="add-td-2">
            <asp:CheckBoxList ID="MembersList" AutoPostBack="True" runat="server"></asp:CheckBoxList>
            <asp:DropDownList ID="MembersListID" Visible="false" runat="server"></asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td></td>
        <td class="add-td-2"><asp:Button ID="SetRollCalls" runat="server" Text="ذخیره" /></td>
    </tr>
</table>