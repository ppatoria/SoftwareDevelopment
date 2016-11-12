(defun list-files()
  (interactive)
  (call-interactively (shell-command (concat "powershell -command "Get-ChildItem " &"))))
