<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDrawLayer
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent

    '������д�ͷţ�����������б�
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Windows ����������������
    Private components As System.ComponentModel.IContainer

    'ע��: ���¹����� Windows ����������������
    '����ʹ�� Windows ����������޸�����
    '��Ҫʹ�ô���༭���޸�����
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("����ͼ")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("ƽ��ͼ")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("������")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("�̶�")
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("����")
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("����ͼ", New System.Windows.Forms.TreeNode() {TreeNode3, TreeNode4, TreeNode5})
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("��ֵ��")
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("��ֵ�����")
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("��ֵ��", New System.Windows.Forms.TreeNode() {TreeNode7, TreeNode8})
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("��ȾԴ")
        Dim TreeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("���ĵ�")
        Dim TreeNode12 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("������")
        Me.TreeView1 = New System.Windows.Forms.TreeView
        Me.SuspendLayout()
        '
        'TreeView1
        '
        Me.TreeView1.CheckBoxes = True
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView1.Location = New System.Drawing.Point(0, 0)
        Me.TreeView1.Name = "TreeView1"
        TreeNode1.Checked = True
        TreeNode1.Name = "LayBackPicture"
        TreeNode1.Text = "����ͼ"
        TreeNode2.Checked = True
        TreeNode2.Name = "LayPlan"
        TreeNode2.Text = "ƽ��ͼ"
        TreeNode3.Checked = True
        TreeNode3.Name = "LayAxis"
        TreeNode3.Text = "������"
        TreeNode4.Checked = True
        TreeNode4.Name = "LayScale"
        TreeNode4.Text = "�̶�"
        TreeNode5.Checked = True
        TreeNode5.Name = "LayGrid"
        TreeNode5.Text = "����"
        TreeNode6.Checked = True
        TreeNode6.Name = "LayAxes"
        TreeNode6.Text = "����ͼ"
        TreeNode7.Checked = True
        TreeNode7.Name = "LayContourLine"
        TreeNode7.Text = "��ֵ��"
        TreeNode8.Checked = True
        TreeNode8.Name = "LayContourPaint"
        TreeNode8.Text = "��ֵ�����"
        TreeNode9.Checked = True
        TreeNode9.Name = "LayContours"
        TreeNode9.Text = "��ֵ��"
        TreeNode10.Checked = True
        TreeNode10.Name = "LaySource"
        TreeNode10.Text = "��ȾԴ"
        TreeNode11.Checked = True
        TreeNode11.Name = "LayCare"
        TreeNode11.Text = "���ĵ�"
        TreeNode12.Checked = True
        TreeNode12.Name = "LayBulding"
        TreeNode12.Text = "������"
        Me.TreeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode6, TreeNode9, TreeNode10, TreeNode11, TreeNode12})
        Me.TreeView1.Size = New System.Drawing.Size(292, 266)
        Me.TreeView1.TabIndex = 0
        '
        'frmDrawLayer
        '
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.TreeView1)
        Me.Name = "frmDrawLayer"
        Me.TabText = "ͼ��"
        Me.Text = "ͼ��"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView

End Class
