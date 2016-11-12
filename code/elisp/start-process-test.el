(defun start-process-test ()
  "start process test"
  (interactive)
  (start-process "my-process" "some-buffer" "cmd")
 )

(defun start-process-shell-command-test ()
  "start process test"
  (interactive)
  (start-process-shell-command "my-process-1" "some-buffer-1" "cmd")
 )
