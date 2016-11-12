(defun list-tests(target)
  "list all the tests"
  (message "%s" target)
  (call-interactively target "--gtest_list_tests")) 

(defun list-files()
  (interactive)
  (call-interactively (shell-command (concat "powershell -command ls" " &"))))
