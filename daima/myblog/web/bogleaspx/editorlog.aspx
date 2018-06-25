<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="editorlog.aspx.cs" Inherits="bogleaspx_editorlog" %>


<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 483px;
        }
        .style2
        {
            width: 61px;
        }
        .style3
        {
            width: 61px;
            height: 68px;
        }
        .style4
        {
            width: 483px;
            height: 68px;
        }
        
   #e1{

	  font-family:隶书;
	position:absolute;
	color:White;
	left:105px;
	top:700px;
	font-size:30px;
}
  #e2{

	  font-family:隶书;
	position:absolute;
	color:White;
	left:195px;
	top:700px;
	font-size:30px;
}
  #e3{

	  font-family:隶书;
	position:absolute;
	color:White;
	left:105px;
	top:780px;
	font-size:30px;
}
#e4{

	  font-family:隶书;
	position:absolute;
	color:White;
	left:195px;
	top:780px;
	font-size:30px;
}
#e5{

	  font-family:隶书;
	position:absolute;
	color:White;
	left:195px;
	top:880px;
	font-size:30px;
}
#e6{

	  font-family:隶书;
	position:absolute;
	color:White;
	left:105px;
	top:900px;
	font-size:30px;
}
#e7{

position:absolute;
	color:White;
	left:192px;
	top:1405px;
            height: 0px;
            width: 355px;
        }
        #e8{

position:absolute;
	color:White;
	left:154px;
	top:1514px;
	
        }
            #e9{

position:absolute;
	color:White;
	left:192px;
	top:1448px;
	
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mineBolge" Runat="Server">

    <div id="e1"><asp:Label ID="Label4" runat="server" Text="标题"></asp:Label></div>
<div id="e2"> <asp:TextBox ID="txttitle" runat="server" Height="30px" Width="189px"></asp:TextBox></div>
<div id="e3"><asp:Label ID="Label1" runat="server" Text="摘要"></asp:Label></div>
<div id="e4"><asp:TextBox ID="txtzhaiyao" runat="server" TextMode="MultiLine" 
        Height="33px" Width="361px"></asp:TextBox></div>
<div id="e6"><asp:Label ID="Label5" runat="server" Text="内容"></asp:Label></div>
<div id="e5"><FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server" Height="500px" 
                 Width="600px">
             </FCKeditorV2:FCKeditor></div>
        
     <div id="e7">
     <asp:Label ID="Label2" runat="server" Text="分类："></asp:Label>
              <asp:RadioButton ID="RadioButton1" runat="server"  Text ="体育"  
        GroupName="a"  />
              <asp:RadioButton ID="RadioButton2" runat="server"  Text ="财经"  GroupName="a" />
              <asp:RadioButton ID="RadioButton3" runat="server"  Text ="房产" GroupName="a" />
              <asp:RadioButton ID="RadioButton4" runat="server"  Text ="娱乐" GroupName="a" />
              <asp:RadioButton ID="RadioButton5" runat="server"  Text ="计算机" GroupName="a" />
              <asp:RadioButton ID="RadioButton6" runat="server"  Text ="其他" GroupName="a" /></div>
                  
             <div id="e9"><asp:Label ID="Label3" runat="server" Text="设置"></asp:Label>
             <asp:CheckBox ID="CheckBox1" runat="server" Text ="发布" /><asp:CheckBox ID="CheckBox2" runat="server" Text="允许评论" /></div>
        
    
     
      
         
           
         
    
              <div id="e8"><asp:Button ID="btn" runat="server" Text="保存" onclick="btn_Click" 
                      Height="40px" Width="160px" BackColor="Black" BorderColor="Black" 
                      Font-Names="隶书" Font-Size="X-Large" ForeColor="White" /> </div>
        
     

</asp:Content>


            