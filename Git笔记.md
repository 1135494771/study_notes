# [Git笔记](#Git笔记)

## 第一次提交GitHub

- ## 1.设置SSH 秘钥

- ## 2.创建项目时设置

  - .gitignore 为 VisualStudio

  - 选择许可证 为 MIT License
  
  - ![img](http://m.qpic.cn/psc?/V54Shkv04DIbIT1um5rp43OUPf260w0R/ruAMsa53pVQWN7FLK88i5giUZOYTlUJUoOnzMgKn0UurWgHPJPaY3hXuNa50FzswpRvq41srxfZuFfeXtChs3FExPbvpchcpxDaz2idga9s!/b&bo=wgMvAwAAAAABB80!&rf=viewer_4)
  
- ## 3.在项目中初始化 git init

- ## 4.在项目中关联git地址

  - git remote add origin [git地址]

- ## 5.拉去指定分支

  - git pull --rebase origin [分支名]

- ## 6.添加git项目中

  - git add .

- ## 7.提交到本地

  - git commit -m 'first commit'

- ## 8.推送到线上分支

  - git push -u origin [分支名]

## 操作已有分支

- ## 1.拉去指定分支

  - git clone -b [分支名] [git项目地址]

- ## 2.创建并切换分支

  - git checkout -b [分支名称]
