# SimpleTimer

![Platform](https://img.shields.io/badge/platform-.NET%20%7C%20WPF-blue?style=for-the-badge)
![Language](https://img.shields.io/badge/language-C%23-green?style=for-the-badge)
![License](https://img.shields.io/badge/license-MPL-purple?style=for-the-badge)

**SimpleTimer** 是一款基于 C# 和 WPF 开发的高颜值、轻量级定时器工具。除了满足日常的基础倒计时需求外，它还专为复杂多任务场景设计，支持多段嵌套计时与桌面悬浮窗交互。

**状态**：缓慢更新中

---

## ✨ 核心特性

* **⏱️ 基础计时**：直观、简单、准确的常规倒计时功能。
* **📂 配置文件管理**：支持将常用的计时流程保存为配置文件（Profile），一键加载，告别重复设置。
* **🔄 多段/嵌套计时**：
    * 支持在一个任务流程中创建**多段计时**。
    * 独创**时间嵌套功能**：次级计时段可以完全包含在上一个时间段内（例如：大任务 45 分钟，内部嵌套 15 分钟的阶段性检查），完美契合复杂的工作与学习工作流。
* **📌 桌面悬浮窗**：计时开始后可开启置顶悬浮窗，支持微型化显示，不占用屏幕空间，让你在专注于其他工作时也能对时间了然于胸。
* **🔔 智能提醒**：每段计时结束时提供及时的视觉与听觉提醒，确保不会错过任何时间节点。

---

## 🚀 快速开始

### 运行环境
* Windows 10 / 11
* [.NET 8.0 Runtime](https://dotnet.microsoft.com/download)

### 安装与使用
1.  前往 [Releases](https://github.com/onear233/SimpleTimer/releases) 页面下载最新的压缩包。
2.  解压后双击运行 `SimpleTimer.exe` 即可启动程序。

---

## 🛠️ 技术栈

* **开发语言**：C#
* **界面框架**：WPF (Windows Presentation Foundation)
* **设计模式**：MVVM (Model-View-ViewModel)


## ⌨️ 参与贡献

如果你在使用过程中发现了 Bug，或者有更好的 Feature 想法，欢迎提交 Issue 或 Pull Request！

1. Fork 本项目
2. 创建你的特性分支 (`git checkout -b feature/AmazingFeature`)
3. 提交你的修改 (`git commit -m 'Add some AmazingFeature'`)
4. 推送到分支 (`git push origin feature/AmazingFeature`)
5. 提交 Pull Request

---

## 📄 开源协议

本项目基于 **MPL 2.0** 开源协议，详情请参阅 [LICENSE](LICENSE) 文件。
