(defun test-report ()
  "gtest report"
  (interactive)
  (helm-swoop :$query "RUN")
  (helm-swoop :$query "OK")
  (helm-swoop :$query "PASSED")
  (helm-swoop :$query "FAILED")
  )
(defun print-line ()
  (interactive)
  (message "%s" (thing-at-point 'line)))
;; TEST_F(class, test)