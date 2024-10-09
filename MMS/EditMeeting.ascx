<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="EditMeeting.ascx.vb" Inherits="MMS.EditMeeting" %>

<h3>افزودن جلسه جدید</h3>
<label id="lblError" runat="server" class="error-label"></label>
<table class="view-tbl">
    <tr>
        <td class="add-td">عنوان :</td>
        <td class="add-td-2"><input id="MTitle" size="40" type="text" runat="server" /></td>
    </tr>
    <tr>
        <td class="add-td">تاریخ برگزاری :</td>
        <td class="add-td-2">
            <span>روز</span>
            <input dir="ltr" id="MDateD" size="2" type="text" runat="server" />
            <span>ماه</span>
            <input dir="ltr" id="MDateM" size="2" type="text" runat="server" />
            <span>سال</span>
            <input dir="ltr" id="MDateY" size="6" type="text" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="add-td">ساعت برگزاری :</td>
        <td class="add-td-2">
            <span>دقیقه</span>
            <input dir="ltr" id="MTimeM" size="2" type="text" runat="server" />
            <span>ساعت</span>
            <input dir="ltr" id="MTimeH" size="2" type="text" runat="server" />
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
        <td class="add-td-2"><asp:Button ID="AddMeeting" runat="server" Text="ذخیره" /></td>
    </tr>
</table>