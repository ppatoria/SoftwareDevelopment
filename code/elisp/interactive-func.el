(defun mul-7 (number)       ; Interactive version.
  "Multiply NUMBER by seven."
  (interactive "nEnter Number: ")
  (message "The result is %d" (* 7 number)))
(defun query-user (x y)
  "…"
  (interactive "sEnter friend's name: \nnEnter friend's age: ")
  (message "Name is: %s, Age is: %d" x y)
)

