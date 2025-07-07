# LCHATLOGBOT | 记录LC服务器的所有客户端聊天日志的机器人

主要开发：114514pig.zip
Copyright (C) 2018-Now **XYLCS/XIT**<br>
Lchatlogbot(2025) by XYLCS/XIT 2025-Now freedom-create in XFCSTD2.<br>
XFCSTD PATH:/XFCSTD2.md

> **注意**：本项目需要自行编译，请参考文末的编译指南。<br>

> [!IMPORTANT]
> 基于LCBOF 1.0.r1.b72 编写

## 主要内容

- 可用于记录LC服务器的所有客户端聊天日志
- 每分钟生成一个日志文件,确保日志方便阅读
- 便于向所有用户公开聊天记录与服务器消息

---

## 如何编译？

请确保已安装 `dotnet` （版本 >= 8.0）、`openssl`（版本 >= 3.0）和 `git`，然后按照以下步骤操作：

```bash
git clone https://github.com/LosefDevLab/lchatlogbot.git
cd lcbof
dotnet build
cd bin
cd Debug
cd net8.0
# 以下内容，仅需要安全通信服务端需要操作
openssl genpkey -algorithm RSA -out sfc.key -aes256
# ^^^生成密钥
openssl req -new -key sfc.key -out sfc.csr
# ^^^生成签名
# 此处仅为演示, 实际建议使用可靠的签名, 否则早晚被破解
# 微软40块钱一份的签名它不香吗？
openssl x509 -req -days 365 -in sfc.csr -signkey sfc.key -out sfc.crt
# ^^^签名认证
openssl pkcs12 -export -out sfc.pfx -inkey sfc.key -in sfc.crt
# ^^^导出
# 以上内容仅服务端需要操作, 客户端连接到这种开启安全通讯的服务器需要在程序同目录下提供服务器开放的安全通讯证书


# 运行
./lchatlogbot

# 使用方法参照Losefchat
```


## 贡献&Git规范标准

CMTMSG规范

- 需要先创建当前要做的内容的计划issues, 这个issues可以是需要修复的、更新计划、功能添加(类似于JIRA工单)
- 当做完这些内容/做了新内容的其中一部分/修改新内容的部分/修复一些bug/合并, 按情况分别提交cmtmsg:
  - Add for #x : xxxxxxx
  - Add part for #x : xxxxxxx
  - Update for #x : xxxxxxx
  - Fix in #x : xxxxxxx
  - Merge branch xx(branchname) to xx(branch) in #x : xxxxxx

Release & tag信息规范

- tag无需标注
- Release标题为版本号
- Release描述需用MD格式
- Release描述需按照以下格式进行编写:

  ```
  本次更新:
  -----
  - (本次阶段的所有CMTMSG)
  -----
  - (更新简述)
  ```

## License

使用 MIT License


